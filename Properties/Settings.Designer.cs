﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maestro_Resizer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.11.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool FirstRun {
            get {
                return ((bool)(this["FirstRun"]));
            }
            set {
                this["FirstRun"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"10x15,(A6) 10x15 см,10,15,False,False;15x21,(A5) 15x21 см,15,21,False,False;21x30,(A4) 21x30 см,21,30,False,False;30x40,(A3) 30x40 см,30,40,False,False;30x42,(A3) 30x42 см,30,42,False,False;40x60,(A2) 40x60 см,40,60,False,False;42x60,(A2) 42x60 см,42,60,False,False;60x80,(A1) 60x80 см,60,80,False,False;10x15,(A6) 10x15 см,10,15,True,False;15x21,(A5) 15x21 см,15,21,True,False;21x30,(A4) 21x30 см,21,30,True,False;30x40,(A3) 30x40 см,30,40,True,False;30x42,(A3) 30x42 см,30,42,True,False;40x60,(A2) 40x60 см,40,60,True,False;42x60,(A2) 42x60 см,42,60,True,False;60x80,(A1) 60x80 см,60,80,True,False")]
        public string Data {
            get {
                return ((string)(this["Data"]));
            }
            set {
                this["Data"] = value;
            }
        }
    }
}
