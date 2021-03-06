﻿using Awesomium.Core;
using Neutronium.Core.WebBrowserEngine.JavascriptObject;
using Neutronium.WebBrowserEngine.Awesomium.Engine;

namespace Neutronium.WebBrowserEngine.Awesomium.Internal
{
    internal static class AwesomiumConverter
    {
        public static IJavascriptObject Convert(this JSValue ivalue)
        {
            return new JSValue_JavascriptObject(ivalue);
        }

        public static IJavascriptObject Convert(this JSObject ivalue)
        {
            return new JSValue_JavascriptObject(ivalue);
        }

        public static JSValue Convert(this IJavascriptObject ivalue)
        {
            return ((JSValue_JavascriptObject) ivalue).JSValue;
        }
    }
}
