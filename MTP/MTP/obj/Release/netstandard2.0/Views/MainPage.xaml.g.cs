//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("MTP.Views.MainPage.xaml", "Views/MainPage.xaml", typeof(global::MTP.Views.MainPage))]

namespace MTP.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\MainPage.xaml")]
    public partial class MainPage : global::Xamarin.Forms.TabbedPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::MTP.Views.TransactionPanel piTransactions;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::MTP.Views.AccountPanel piAccounts;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::MTP.Views.ProfilePanel piProfile;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MainPage));
            piTransactions = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MTP.Views.TransactionPanel>(this, "piTransactions");
            piAccounts = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MTP.Views.AccountPanel>(this, "piAccounts");
            piProfile = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MTP.Views.ProfilePanel>(this, "piProfile");
        }
    }
}