using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CSharpWarrior.Compiler;

namespace CSharpWarrior.Compiler
{
    public class WhitelistValidator
    {
        public WhitelistValidator()
        {
        }

        public void Validate(AssemblyDefinition suspect)
        {
            var types = from mod in suspect.Modules
                                   from t in mod.Types
                                 select t;

            foreach(var t in types) {
                Validate(t);
            }

            var methods = from t in types
                                   from m in t.Methods
                                   select m;

            foreach(var m in methods) {
                Validate(m.Body);
            }
        }

        private static void Validate(TypeDefinition type)
        {
            if(type.BaseType != null && type.BaseType.FullName != "System.Object") {
                throw new CodeExecutionException(string.Format("Dangerous code found: {0} inherits from {1}", type.FullName, type.BaseType));
            }
        }

        private static void Validate(MethodBody body)
        {
            var calls = (from i in body.Instructions
                                  let v = new InstructionValidator(body, i)
                                  where !v.IsValid()
                                  select i).ToArray();
            foreach(var c in calls) {
                throw new CodeExecutionException("Dangerous code found: " + c.ToString());
            }
        }

        private class InstructionValidator
        {
            private readonly Instruction instruction;
            private readonly MethodBody methodBody;

            public InstructionValidator(MethodBody methodBody, Instruction instruction)
            {
                this.instruction = instruction;
                this.methodBody = methodBody;
            }

            public bool IsValid()
            {
                return !IsCall || OperandIsSafe;
            }

            bool IsCall { 
                get { return OpCodeIsCall || OpCodeIsCallVirt || OpCodeIsConstructor; }
            }

            bool OpCodeIsCall { 
                get { return (instruction.OpCode.Code == Code.Call); }
            }

            bool OpCodeIsCallVirt { 
                get { return instruction.OpCode.Code == Code.Callvirt; }
            }

            bool OpCodeIsConstructor {
                get { return instruction.OpCode.Code == Code.Newobj; }
            }

            bool OperandIsSafe {
                get { return OperandIsBaseClassMethod || OperandIsPrimitiveMethod || OperandIsPrivateMethod || OperandIsInDomain; }
            }

            bool OperandIsBaseClassMethod {
                get { return OperandAsMethod.DeclaringType == methodBody.Method.DeclaringType.BaseType; }
            }

            bool OperandIsPrimitiveMethod {
                get { return OperandAsMethod.DeclaringType.IsPrimitive; }
            }

            bool OperandIsPrivateMethod {
                get { return OperandAsMethod.DeclaringType == methodBody.Method.DeclaringType; }
            }

            bool OperandIsInDomain {
                get { return OperandAsMethod.DeclaringType.Namespace == "CSharpWarrior.Domain"; }
            }

            MethodReference OperandAsMethod {
                get { return ((MethodReference)instruction.Operand); }
            }

            private bool IsBaseConstructorCall()
            {
                var method = (MethodReference)instruction.Operand;
                return method.DeclaringType == methodBody.Method.DeclaringType.BaseType;
            }
        }
    }
}

