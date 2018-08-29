using strange.extensions.signal.impl;

namespace StrangeJson
{
    public class ThrowDebugSignal : Signal<string> {}
    public class CreateViewSignal : Signal<IGeneratedView> {}
}