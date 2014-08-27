﻿using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;
using System.CodeDom.Compiler;
using CSharpWarrior.Domain;

namespace CSharpWarrior.Web
{
    public class LevelModule : NancyModule
    {
        private class LevelCode
        {
            public string Code { get; set; }
        }

        public LevelModule()
        {
            Get["/level/{currentLevel}"] = args => {
                return new LevelResponse { 
                    Tiles = new [] { new Tile { HeroIsHere = true }, new Tile(), new Tile { IsExit = true} },
                    Objective = "Be Awesome!",
                };
            };

            Post["/level/{currentLevel}"] = args => {
                var code = this.Bind<LevelCode>().Code;
                return PostCodeToLevel(code);
            };
        }
            
        public CodeResultResponse PostCodeToLevel(string code)
        {
            var compiler = new PlayerCompiler();
            var compileResult = compiler.Compile(code);

            return compileResult.HasErrors() 
                ? CodeResultResponse.CompileError(compileResult.Errors) 
                   : CodeResultResponse.Success();
        }

    }
}

