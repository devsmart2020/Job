﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Meteoro.Services {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Meteoro.Services.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a http://10.10.49.131:9096/.
        /// </summary>
        internal static string BaseURL {
            get {
                return ResourceManager.GetString("BaseURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a http://10.10.44.132:9092/.
        /// </summary>
        internal static string BaseURL1 {
            get {
                return ResourceManager.GetString("BaseURL1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a api/Cosechas.
        /// </summary>
        internal static string CrearCosechaURL {
            get {
                return ResourceManager.GetString("CrearCosechaURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a application/json.
        /// </summary>
        internal static string RequestHeaders {
            get {
                return ResourceManager.GetString("RequestHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a $&quot;api/Cosechas/&quot;.
        /// </summary>
        internal static string RutaApiCosecha {
            get {
                return ResourceManager.GetString("RutaApiCosecha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a api/Empleados/account/.
        /// </summary>
        internal static string RutaApiLogin {
            get {
                return ResourceManager.GetString("RutaApiLogin", resourceCulture);
            }
        }
    }
}