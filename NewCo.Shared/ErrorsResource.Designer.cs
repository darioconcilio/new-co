﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewCo.Shared {
    using System;
    
    
    /// <summary>
    ///   Classe di risorse fortemente tipizzata per la ricerca di stringhe localizzate e così via.
    /// </summary>
    // Questa classe è stata generata automaticamente dalla classe StronglyTypedResourceBuilder.
    // tramite uno strumento quale ResGen o Visual Studio.
    // Per aggiungere o rimuovere un membro, modificare il file con estensione ResX ed eseguire nuovamente ResGen
    // con l'opzione /str oppure ricompilare il progetto VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ErrorsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorsResource() {
        }
        
        /// <summary>
        ///   Restituisce l'istanza di ResourceManager nella cache utilizzata da questa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NewCo.Shared.ErrorsResource", typeof(ErrorsResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Esegue l'override della proprietà CurrentUICulture del thread corrente per tutte le
        ///   ricerche di risorse eseguite utilizzando questa classe di risorse fortemente tipizzata.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Country.
        /// </summary>
        public static string Country_Name {
            get {
                return ResourceManager.GetString("Country_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Address.
        /// </summary>
        public static string Customer_Address {
            get {
                return ResourceManager.GetString("Customer_Address", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a City.
        /// </summary>
        public static string Customer_City {
            get {
                return ResourceManager.GetString("Customer_City", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Code.
        /// </summary>
        public static string Customer_Code {
            get {
                return ResourceManager.GetString("Customer_Code", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Country.
        /// </summary>
        public static string Customer_CountryId {
            get {
                return ResourceManager.GetString("Customer_CountryId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a County.
        /// </summary>
        public static string Customer_CountyId {
            get {
                return ResourceManager.GetString("Customer_CountyId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Name.
        /// </summary>
        public static string Customer_Name {
            get {
                return ResourceManager.GetString("Customer_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Post Code.
        /// </summary>
        public static string Customer_PostCode {
            get {
                return ResourceManager.GetString("Customer_PostCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a VAT Reg. No..
        /// </summary>
        public static string Customer_VATRegistrationCode {
            get {
                return ResourceManager.GetString("Customer_VATRegistrationCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a {0} must has max {1} characters	{0}.
        /// </summary>
        public static string MaxLengthErrorMessage {
            get {
                return ResourceManager.GetString("MaxLengthErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a Required Field.
        /// </summary>
        public static string RequiredField {
            get {
                return ResourceManager.GetString("RequiredField", resourceCulture);
            }
        }
    }
}
