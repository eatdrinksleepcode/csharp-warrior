using System.Diagnostics;

// XBuild doesn't add this, but Nancy uses it to detect debug mode (for view caching etc)
#if DEBUG
[Debuggable (DebuggableAttribute.DebuggingModes.Default)]
#endif