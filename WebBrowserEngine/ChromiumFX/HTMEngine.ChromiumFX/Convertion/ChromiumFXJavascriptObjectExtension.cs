﻿using Chromium.Remote;
using Neutronium.Core.WebBrowserEngine.JavascriptObject;
using Neutronium.WebBrowserEngine.ChromiumFx.V8Object;
using Neutronium.Core.Infra;

namespace Neutronium.WebBrowserEngine.ChromiumFx.Convertion 
{
    public static class ChromiumFxJavascriptObjectExtension 
    {
        public static IJavascriptObject Convert(this CfrV8Value cfrV8Value) 
        {
            if ((cfrV8Value == null) || (!cfrV8Value.IsObject)) 
                return ConvertBasic(cfrV8Value ?? CfrV8Value.CreateUndefined());

            return ConvertObject(cfrV8Value); 
        }

        public static IJavascriptObject ConvertBasic(this CfrV8Value cfrV8Value)
        {
            return new ChromiumFXJavascriptSimple(cfrV8Value);
        }

        public static IJavascriptObject ConvertBasic(this CfrV8Value cfrV8Value, uint id)
        {
            return new ChromiumFXJavascriptSimpleWithId(cfrV8Value, id);
        }

        public static IJavascriptObject ConvertObject(this CfrV8Value cfrV8Value)
        {
            return new ChromiumFXJavascriptObject(cfrV8Value);
        }

        public static IJavascriptObject ConvertObject(this CfrV8Value cfrV8Value, uint id)
        {
            return new ChromiumFXJavascriptObjectWithId(cfrV8Value, id);
        }

        public static CfrV8Value Convert(this IJavascriptObject javascriptObject) 
        {
            var chromiumObject = javascriptObject as ICfxJavascriptObject;
            return chromiumObject.Raw;
        }

        public static IJavascriptObject[] Convert(this CfrV8Value[] cfrV8Values)
        {
            return cfrV8Values.ToArray(javascriptObject =>javascriptObject.Convert());
        }

        public static CfrV8Value[] Convert(this IJavascriptObject[] javascriptObjects) 
        {
            return javascriptObjects.ToArray(javascriptObject => javascriptObject.Convert());
        }
    }
}
