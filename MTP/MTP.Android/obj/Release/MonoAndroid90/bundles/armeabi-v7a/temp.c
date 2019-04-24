void (*mono_jit_set_aot_mode_ptr) (int mode);
/* This source code was produced by mkbundle, do not edit */

#ifndef NULL
#define NULL (void *)0
#endif

typedef struct {
	const char *name;
	const unsigned char *data;
	const unsigned int size;
} MonoBundledAssembly;
void          mono_register_bundled_assemblies (const MonoBundledAssembly **assemblies);
void          mono_register_config_for_assembly (const char* assembly_name, const char* config_xml);

#define MONO_AOT_MODE_NORMAL 1
#define MONO_AOT_MODE_FULL 3
#define MONO_AOT_MODE_LLVMONLY 4
typedef struct _compressed_data {
	MonoBundledAssembly assembly;
	int compressed_size;
} CompressedAssembly;

extern const unsigned char assembly_data_MTP_Android_dll [];
static CompressedAssembly assembly_bundle_MTP_Android_dll = {{"MTP.Android.dll", assembly_data_MTP_Android_dll, 104448}, 38149};
extern const unsigned char assembly_data_Castle_Core_dll [];
static CompressedAssembly assembly_bundle_Castle_Core_dll = {{"Castle.Core.dll", assembly_data_Castle_Core_dll, 266240}, 110049};
extern const unsigned char assembly_data_FormsViewGroup_dll [];
static CompressedAssembly assembly_bundle_FormsViewGroup_dll = {{"FormsViewGroup.dll", assembly_data_FormsViewGroup_dll, 12800}, 4977};
extern const unsigned char assembly_data_Microsoft_Data_Sqlite_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Data_Sqlite_dll = {{"Microsoft.Data.Sqlite.dll", assembly_data_Microsoft_Data_Sqlite_dll, 123904}, 48095};
extern const unsigned char assembly_data_Microsoft_EntityFrameworkCore_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Microsoft_EntityFrameworkCore_Abstractions_dll = {{"Microsoft.EntityFrameworkCore.Abstractions.dll", assembly_data_Microsoft_EntityFrameworkCore_Abstractions_dll, 11264}, 4827};
extern const unsigned char assembly_data_Microsoft_EntityFrameworkCore_Design_dll [];
static CompressedAssembly assembly_bundle_Microsoft_EntityFrameworkCore_Design_dll = {{"Microsoft.EntityFrameworkCore.Design.dll", assembly_data_Microsoft_EntityFrameworkCore_Design_dll, 224768}, 87334};
extern const unsigned char assembly_data_Microsoft_EntityFrameworkCore_dll [];
static CompressedAssembly assembly_bundle_Microsoft_EntityFrameworkCore_dll = {{"Microsoft.EntityFrameworkCore.dll", assembly_data_Microsoft_EntityFrameworkCore_dll, 1408512}, 476375};
extern const unsigned char assembly_data_Microsoft_EntityFrameworkCore_Proxies_dll [];
static CompressedAssembly assembly_bundle_Microsoft_EntityFrameworkCore_Proxies_dll = {{"Microsoft.EntityFrameworkCore.Proxies.dll", assembly_data_Microsoft_EntityFrameworkCore_Proxies_dll, 36352}, 16102};
extern const unsigned char assembly_data_Microsoft_EntityFrameworkCore_Relational_dll [];
static CompressedAssembly assembly_bundle_Microsoft_EntityFrameworkCore_Relational_dll = {{"Microsoft.EntityFrameworkCore.Relational.dll", assembly_data_Microsoft_EntityFrameworkCore_Relational_dll, 747520}, 269822};
extern const unsigned char assembly_data_Microsoft_EntityFrameworkCore_Sqlite_dll [];
static CompressedAssembly assembly_bundle_Microsoft_EntityFrameworkCore_Sqlite_dll = {{"Microsoft.EntityFrameworkCore.Sqlite.dll", assembly_data_Microsoft_EntityFrameworkCore_Sqlite_dll, 99840}, 40403};
extern const unsigned char assembly_data_Microsoft_Extensions_Caching_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Caching_Abstractions_dll = {{"Microsoft.Extensions.Caching.Abstractions.dll", assembly_data_Microsoft_Extensions_Caching_Abstractions_dll, 17408}, 7109};
extern const unsigned char assembly_data_Microsoft_Extensions_Caching_Memory_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Caching_Memory_dll = {{"Microsoft.Extensions.Caching.Memory.dll", assembly_data_Microsoft_Extensions_Caching_Memory_dll, 22528}, 10308};
extern const unsigned char assembly_data_Microsoft_Extensions_Configuration_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Configuration_Abstractions_dll = {{"Microsoft.Extensions.Configuration.Abstractions.dll", assembly_data_Microsoft_Extensions_Configuration_Abstractions_dll, 10752}, 4455};
extern const unsigned char assembly_data_Microsoft_Extensions_Configuration_Binder_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Configuration_Binder_dll = {{"Microsoft.Extensions.Configuration.Binder.dll", assembly_data_Microsoft_Extensions_Configuration_Binder_dll, 15872}, 7195};
extern const unsigned char assembly_data_Microsoft_Extensions_Configuration_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Configuration_dll = {{"Microsoft.Extensions.Configuration.dll", assembly_data_Microsoft_Extensions_Configuration_dll, 16384}, 7700};
extern const unsigned char assembly_data_Microsoft_Extensions_DependencyInjection_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_DependencyInjection_Abstractions_dll = {{"Microsoft.Extensions.DependencyInjection.Abstractions.dll", assembly_data_Microsoft_Extensions_DependencyInjection_Abstractions_dll, 27136}, 10852};
extern const unsigned char assembly_data_Microsoft_Extensions_DependencyInjection_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_DependencyInjection_dll = {{"Microsoft.Extensions.DependencyInjection.dll", assembly_data_Microsoft_Extensions_DependencyInjection_dll, 43008}, 18953};
extern const unsigned char assembly_data_Microsoft_Extensions_Logging_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Logging_Abstractions_dll = {{"Microsoft.Extensions.Logging.Abstractions.dll", assembly_data_Microsoft_Extensions_Logging_Abstractions_dll, 37888}, 16069};
extern const unsigned char assembly_data_Microsoft_Extensions_Logging_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Logging_dll = {{"Microsoft.Extensions.Logging.dll", assembly_data_Microsoft_Extensions_Logging_dll, 22016}, 10088};
extern const unsigned char assembly_data_Microsoft_Extensions_Options_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Options_dll = {{"Microsoft.Extensions.Options.dll", assembly_data_Microsoft_Extensions_Options_dll, 31232}, 12771};
extern const unsigned char assembly_data_Microsoft_Extensions_Primitives_dll [];
static CompressedAssembly assembly_bundle_Microsoft_Extensions_Primitives_dll = {{"Microsoft.Extensions.Primitives.dll", assembly_data_Microsoft_Extensions_Primitives_dll, 26112}, 11317};
extern const unsigned char assembly_data_MTP_dll [];
static CompressedAssembly assembly_bundle_MTP_dll = {{"MTP.dll", assembly_data_MTP_dll, 111616}, 41046};
extern const unsigned char assembly_data_Newtonsoft_Json_dll [];
static CompressedAssembly assembly_bundle_Newtonsoft_Json_dll = {{"Newtonsoft.Json.dll", assembly_data_Newtonsoft_Json_dll, 467456}, 187053};
extern const unsigned char assembly_data_PCLStorage_Abstractions_dll [];
static CompressedAssembly assembly_bundle_PCLStorage_Abstractions_dll = {{"PCLStorage.Abstractions.dll", assembly_data_PCLStorage_Abstractions_dll, 10752}, 4509};
extern const unsigned char assembly_data_PCLStorage_Standard_dll [];
static CompressedAssembly assembly_bundle_PCLStorage_Standard_dll = {{"PCLStorage.Standard.dll", assembly_data_PCLStorage_Standard_dll, 20480}, 8800};
extern const unsigned char assembly_data_Plugin_Settings_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Plugin_Settings_Abstractions_dll = {{"Plugin.Settings.Abstractions.dll", assembly_data_Plugin_Settings_Abstractions_dll, 5120}, 1700};
extern const unsigned char assembly_data_Plugin_Settings_dll [];
static CompressedAssembly assembly_bundle_Plugin_Settings_dll = {{"Plugin.Settings.dll", assembly_data_Plugin_Settings_dll, 11776}, 5244};
extern const unsigned char assembly_data_Prism_dll [];
static CompressedAssembly assembly_bundle_Prism_dll = {{"Prism.dll", assembly_data_Prism_dll, 64000}, 27748};
extern const unsigned char assembly_data_Prism_Forms_dll [];
static CompressedAssembly assembly_bundle_Prism_Forms_dll = {{"Prism.Forms.dll", assembly_data_Prism_Forms_dll, 94208}, 39957};
extern const unsigned char assembly_data_Prism_Unity_Forms_dll [];
static CompressedAssembly assembly_bundle_Prism_Unity_Forms_dll = {{"Prism.Unity.Forms.dll", assembly_data_Prism_Unity_Forms_dll, 16264}, 9003};
extern const unsigned char assembly_data_Remotion_Linq_dll [];
static CompressedAssembly assembly_bundle_Remotion_Linq_dll = {{"Remotion.Linq.dll", assembly_data_Remotion_Linq_dll, 177664}, 67760};
extern const unsigned char assembly_data_SQLitePCLRaw_batteries_green_dll [];
static CompressedAssembly assembly_bundle_SQLitePCLRaw_batteries_green_dll = {{"SQLitePCLRaw.batteries_green.dll", assembly_data_SQLitePCLRaw_batteries_green_dll, 5120}, 1919};
extern const unsigned char assembly_data_SQLitePCLRaw_batteries_v2_dll [];
static CompressedAssembly assembly_bundle_SQLitePCLRaw_batteries_v2_dll = {{"SQLitePCLRaw.batteries_v2.dll", assembly_data_SQLitePCLRaw_batteries_v2_dll, 5120}, 1922};
extern const unsigned char assembly_data_SQLitePCLRaw_core_dll [];
static CompressedAssembly assembly_bundle_SQLitePCLRaw_core_dll = {{"SQLitePCLRaw.core.dll", assembly_data_SQLitePCLRaw_core_dll, 38400}, 13033};
extern const unsigned char assembly_data_SQLitePCLRaw_lib_e_sqlite3_dll [];
static CompressedAssembly assembly_bundle_SQLitePCLRaw_lib_e_sqlite3_dll = {{"SQLitePCLRaw.lib.e_sqlite3.dll", assembly_data_SQLitePCLRaw_lib_e_sqlite3_dll, 4608}, 1827};
extern const unsigned char assembly_data_SQLitePCLRaw_provider_e_sqlite3_dll [];
static CompressedAssembly assembly_bundle_SQLitePCLRaw_provider_e_sqlite3_dll = {{"SQLitePCLRaw.provider.e_sqlite3.dll", assembly_data_SQLitePCLRaw_provider_e_sqlite3_dll, 38912}, 15151};
extern const unsigned char assembly_data_System_Buffers_dll [];
static CompressedAssembly assembly_bundle_System_Buffers_dll = {{"System.Buffers.dll", assembly_data_System_Buffers_dll, 11776}, 5352};
extern const unsigned char assembly_data_System_Collections_Immutable_dll [];
static CompressedAssembly assembly_bundle_System_Collections_Immutable_dll = {{"System.Collections.Immutable.dll", assembly_data_System_Collections_Immutable_dll, 285696}, 127997};
extern const unsigned char assembly_data_System_Diagnostics_DiagnosticSource_dll [];
static CompressedAssembly assembly_bundle_System_Diagnostics_DiagnosticSource_dll = {{"System.Diagnostics.DiagnosticSource.dll", assembly_data_System_Diagnostics_DiagnosticSource_dll, 27648}, 11977};
extern const unsigned char assembly_data_System_Interactive_Async_dll [];
static CompressedAssembly assembly_bundle_System_Interactive_Async_dll = {{"System.Interactive.Async.dll", assembly_data_System_Interactive_Async_dll, 220672}, 79615};
extern const unsigned char assembly_data_System_Memory_dll [];
static CompressedAssembly assembly_bundle_System_Memory_dll = {{"System.Memory.dll", assembly_data_System_Memory_dll, 16384}, 7510};
extern const unsigned char assembly_data_System_Runtime_CompilerServices_Unsafe_dll [];
static CompressedAssembly assembly_bundle_System_Runtime_CompilerServices_Unsafe_dll = {{"System.Runtime.CompilerServices.Unsafe.dll", assembly_data_System_Runtime_CompilerServices_Unsafe_dll, 5632}, 2200};
extern const unsigned char assembly_data_Unity_Abstractions_dll [];
static CompressedAssembly assembly_bundle_Unity_Abstractions_dll = {{"Unity.Abstractions.dll", assembly_data_Unity_Abstractions_dll, 78336}, 30389};
extern const unsigned char assembly_data_Unity_Container_dll [];
static CompressedAssembly assembly_bundle_Unity_Container_dll = {{"Unity.Container.dll", assembly_data_Unity_Container_dll, 101376}, 38930};
extern const unsigned char assembly_data_weekysoft_store_dll [];
static CompressedAssembly assembly_bundle_weekysoft_store_dll = {{"weekysoft.store.dll", assembly_data_weekysoft_store_dll, 26624}, 12559};
extern const unsigned char assembly_data_Xamarin_Android_Arch_Core_Common_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Arch_Core_Common_dll = {{"Xamarin.Android.Arch.Core.Common.dll", assembly_data_Xamarin_Android_Arch_Core_Common_dll, 5120}, 1941};
extern const unsigned char assembly_data_Xamarin_Android_Arch_Lifecycle_Common_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Arch_Lifecycle_Common_dll = {{"Xamarin.Android.Arch.Lifecycle.Common.dll", assembly_data_Xamarin_Android_Arch_Lifecycle_Common_dll, 14848}, 5450};
extern const unsigned char assembly_data_Xamarin_Android_Arch_Lifecycle_Runtime_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Arch_Lifecycle_Runtime_dll = {{"Xamarin.Android.Arch.Lifecycle.Runtime.dll", assembly_data_Xamarin_Android_Arch_Lifecycle_Runtime_dll, 5120}, 1963};
extern const unsigned char assembly_data_Xamarin_Android_Support_Animated_Vector_Drawable_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Animated_Vector_Drawable_dll = {{"Xamarin.Android.Support.Animated.Vector.Drawable.dll", assembly_data_Xamarin_Android_Support_Animated_Vector_Drawable_dll, 6144}, 2233};
extern const unsigned char assembly_data_Xamarin_Android_Support_Annotations_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Annotations_dll = {{"Xamarin.Android.Support.Annotations.dll", assembly_data_Xamarin_Android_Support_Annotations_dll, 5632}, 2147};
extern const unsigned char assembly_data_Xamarin_Android_Support_Compat_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Compat_dll = {{"Xamarin.Android.Support.Compat.dll", assembly_data_Xamarin_Android_Support_Compat_dll, 160256}, 40431};
extern const unsigned char assembly_data_Xamarin_Android_Support_Core_UI_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Core_UI_dll = {{"Xamarin.Android.Support.Core.UI.dll", assembly_data_Xamarin_Android_Support_Core_UI_dll, 107008}, 29240};
extern const unsigned char assembly_data_Xamarin_Android_Support_Core_Utils_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Core_Utils_dll = {{"Xamarin.Android.Support.Core.Utils.dll", assembly_data_Xamarin_Android_Support_Core_Utils_dll, 32768}, 10266};
extern const unsigned char assembly_data_Xamarin_Android_Support_Design_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Design_dll = {{"Xamarin.Android.Support.Design.dll", assembly_data_Xamarin_Android_Support_Design_dll, 54272}, 14939};
extern const unsigned char assembly_data_Xamarin_Android_Support_Fragment_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Fragment_dll = {{"Xamarin.Android.Support.Fragment.dll", assembly_data_Xamarin_Android_Support_Fragment_dll, 154112}, 37202};
extern const unsigned char assembly_data_Xamarin_Android_Support_Media_Compat_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Media_Compat_dll = {{"Xamarin.Android.Support.Media.Compat.dll", assembly_data_Xamarin_Android_Support_Media_Compat_dll, 6656}, 2366};
extern const unsigned char assembly_data_Xamarin_Android_Support_Transition_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Transition_dll = {{"Xamarin.Android.Support.Transition.dll", assembly_data_Xamarin_Android_Support_Transition_dll, 10752}, 2756};
extern const unsigned char assembly_data_Xamarin_Android_Support_v4_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_v4_dll = {{"Xamarin.Android.Support.v4.dll", assembly_data_Xamarin_Android_Support_v4_dll, 8704}, 2953};
extern const unsigned char assembly_data_Xamarin_Android_Support_v7_AppCompat_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_v7_AppCompat_dll = {{"Xamarin.Android.Support.v7.AppCompat.dll", assembly_data_Xamarin_Android_Support_v7_AppCompat_dll, 323584}, 79849};
extern const unsigned char assembly_data_Xamarin_Android_Support_v7_CardView_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_v7_CardView_dll = {{"Xamarin.Android.Support.v7.CardView.dll", assembly_data_Xamarin_Android_Support_v7_CardView_dll, 16384}, 5801};
extern const unsigned char assembly_data_Xamarin_Android_Support_v7_MediaRouter_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_v7_MediaRouter_dll = {{"Xamarin.Android.Support.v7.MediaRouter.dll", assembly_data_Xamarin_Android_Support_v7_MediaRouter_dll, 5632}, 2037};
extern const unsigned char assembly_data_Xamarin_Android_Support_v7_Palette_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_v7_Palette_dll = {{"Xamarin.Android.Support.v7.Palette.dll", assembly_data_Xamarin_Android_Support_v7_Palette_dll, 5120}, 1976};
extern const unsigned char assembly_data_Xamarin_Android_Support_v7_RecyclerView_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_v7_RecyclerView_dll = {{"Xamarin.Android.Support.v7.RecyclerView.dll", assembly_data_Xamarin_Android_Support_v7_RecyclerView_dll, 6144}, 2275};
extern const unsigned char assembly_data_Xamarin_Android_Support_Vector_Drawable_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Android_Support_Vector_Drawable_dll = {{"Xamarin.Android.Support.Vector.Drawable.dll", assembly_data_Xamarin_Android_Support_Vector_Drawable_dll, 5120}, 1991};
extern const unsigned char assembly_data_Xamarin_Forms_Core_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Forms_Core_dll = {{"Xamarin.Forms.Core.dll", assembly_data_Xamarin_Forms_Core_dll, 684544}, 265873};
extern const unsigned char assembly_data_Xamarin_Forms_Platform_Android_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Forms_Platform_Android_dll = {{"Xamarin.Forms.Platform.Android.dll", assembly_data_Xamarin_Forms_Platform_Android_dll, 348264}, 149750};
extern const unsigned char assembly_data_Xamarin_Forms_Platform_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Forms_Platform_dll = {{"Xamarin.Forms.Platform.dll", assembly_data_Xamarin_Forms_Platform_dll, 16984}, 7044};
extern const unsigned char assembly_data_Xamarin_Forms_Xaml_dll [];
static CompressedAssembly assembly_bundle_Xamarin_Forms_Xaml_dll = {{"Xamarin.Forms.Xaml.dll", assembly_data_Xamarin_Forms_Xaml_dll, 83968}, 36137};
extern const unsigned char assembly_data_Java_Interop_dll [];
static CompressedAssembly assembly_bundle_Java_Interop_dll = {{"Java.Interop.dll", assembly_data_Java_Interop_dll, 160256}, 54248};
extern const unsigned char assembly_data_Microsoft_CSharp_dll [];
static CompressedAssembly assembly_bundle_Microsoft_CSharp_dll = {{"Microsoft.CSharp.dll", assembly_data_Microsoft_CSharp_dll, 318976}, 131630};
extern const unsigned char assembly_data_Mono_Android_dll [];
static CompressedAssembly assembly_bundle_Mono_Android_dll = {{"Mono.Android.dll", assembly_data_Mono_Android_dll, 1365504}, 353544};
extern const unsigned char assembly_data_mscorlib_dll [];
static CompressedAssembly assembly_bundle_mscorlib_dll = {{"mscorlib.dll", assembly_data_mscorlib_dll, 2188800}, 773915};
extern const unsigned char assembly_data_System_Core_dll [];
static CompressedAssembly assembly_bundle_System_Core_dll = {{"System.Core.dll", assembly_data_System_Core_dll, 996352}, 338893};
extern const unsigned char assembly_data_System_dll [];
static CompressedAssembly assembly_bundle_System_dll = {{"System.dll", assembly_data_System_dll, 759296}, 313279};
extern const unsigned char assembly_data_System_Xml_dll [];
static CompressedAssembly assembly_bundle_System_Xml_dll = {{"System.Xml.dll", assembly_data_System_Xml_dll, 1100800}, 399506};
extern const unsigned char assembly_data_System_Xml_Linq_dll [];
static CompressedAssembly assembly_bundle_System_Xml_Linq_dll = {{"System.Xml.Linq.dll", assembly_data_System_Xml_Linq_dll, 61952}, 25737};
extern const unsigned char assembly_data_System_Reflection_TypeExtensions_dll [];
static CompressedAssembly assembly_bundle_System_Reflection_TypeExtensions_dll = {{"System.Reflection.TypeExtensions.dll", assembly_data_System_Reflection_TypeExtensions_dll, 6656}, 2522};
extern const unsigned char assembly_data_System_Data_dll [];
static CompressedAssembly assembly_bundle_System_Data_dll = {{"System.Data.dll", assembly_data_System_Data_dll, 769536}, 269485};
extern const unsigned char assembly_data_System_Numerics_dll [];
static CompressedAssembly assembly_bundle_System_Numerics_dll = {{"System.Numerics.dll", assembly_data_System_Numerics_dll, 38912}, 17942};
extern const unsigned char assembly_data_System_Transactions_dll [];
static CompressedAssembly assembly_bundle_System_Transactions_dll = {{"System.Transactions.dll", assembly_data_System_Transactions_dll, 14848}, 6537};
extern const unsigned char assembly_data_System_Net_Http_dll [];
static CompressedAssembly assembly_bundle_System_Net_Http_dll = {{"System.Net.Http.dll", assembly_data_System_Net_Http_dll, 75776}, 33666};
extern const unsigned char assembly_data_System_Runtime_Serialization_dll [];
static CompressedAssembly assembly_bundle_System_Runtime_Serialization_dll = {{"System.Runtime.Serialization.dll", assembly_data_System_Runtime_Serialization_dll, 516096}, 192199};
extern const unsigned char assembly_data_System_ServiceModel_Internals_dll [];
static CompressedAssembly assembly_bundle_System_ServiceModel_Internals_dll = {{"System.ServiceModel.Internals.dll", assembly_data_System_ServiceModel_Internals_dll, 56320}, 21135};
extern const unsigned char assembly_data_System_ComponentModel_DataAnnotations_dll [];
static CompressedAssembly assembly_bundle_System_ComponentModel_DataAnnotations_dll = {{"System.ComponentModel.DataAnnotations.dll", assembly_data_System_ComponentModel_DataAnnotations_dll, 7168}, 2814};
extern const unsigned char assembly_data_Mono_Security_dll [];
static CompressedAssembly assembly_bundle_Mono_Security_dll = {{"Mono.Security.dll", assembly_data_Mono_Security_dll, 174080}, 74330};

static const CompressedAssembly *compressed [] = {
	&assembly_bundle_MTP_Android_dll,
	&assembly_bundle_Castle_Core_dll,
	&assembly_bundle_FormsViewGroup_dll,
	&assembly_bundle_Microsoft_Data_Sqlite_dll,
	&assembly_bundle_Microsoft_EntityFrameworkCore_Abstractions_dll,
	&assembly_bundle_Microsoft_EntityFrameworkCore_Design_dll,
	&assembly_bundle_Microsoft_EntityFrameworkCore_dll,
	&assembly_bundle_Microsoft_EntityFrameworkCore_Proxies_dll,
	&assembly_bundle_Microsoft_EntityFrameworkCore_Relational_dll,
	&assembly_bundle_Microsoft_EntityFrameworkCore_Sqlite_dll,
	&assembly_bundle_Microsoft_Extensions_Caching_Abstractions_dll,
	&assembly_bundle_Microsoft_Extensions_Caching_Memory_dll,
	&assembly_bundle_Microsoft_Extensions_Configuration_Abstractions_dll,
	&assembly_bundle_Microsoft_Extensions_Configuration_Binder_dll,
	&assembly_bundle_Microsoft_Extensions_Configuration_dll,
	&assembly_bundle_Microsoft_Extensions_DependencyInjection_Abstractions_dll,
	&assembly_bundle_Microsoft_Extensions_DependencyInjection_dll,
	&assembly_bundle_Microsoft_Extensions_Logging_Abstractions_dll,
	&assembly_bundle_Microsoft_Extensions_Logging_dll,
	&assembly_bundle_Microsoft_Extensions_Options_dll,
	&assembly_bundle_Microsoft_Extensions_Primitives_dll,
	&assembly_bundle_MTP_dll,
	&assembly_bundle_Newtonsoft_Json_dll,
	&assembly_bundle_PCLStorage_Abstractions_dll,
	&assembly_bundle_PCLStorage_Standard_dll,
	&assembly_bundle_Plugin_Settings_Abstractions_dll,
	&assembly_bundle_Plugin_Settings_dll,
	&assembly_bundle_Prism_dll,
	&assembly_bundle_Prism_Forms_dll,
	&assembly_bundle_Prism_Unity_Forms_dll,
	&assembly_bundle_Remotion_Linq_dll,
	&assembly_bundle_SQLitePCLRaw_batteries_green_dll,
	&assembly_bundle_SQLitePCLRaw_batteries_v2_dll,
	&assembly_bundle_SQLitePCLRaw_core_dll,
	&assembly_bundle_SQLitePCLRaw_lib_e_sqlite3_dll,
	&assembly_bundle_SQLitePCLRaw_provider_e_sqlite3_dll,
	&assembly_bundle_System_Buffers_dll,
	&assembly_bundle_System_Collections_Immutable_dll,
	&assembly_bundle_System_Diagnostics_DiagnosticSource_dll,
	&assembly_bundle_System_Interactive_Async_dll,
	&assembly_bundle_System_Memory_dll,
	&assembly_bundle_System_Runtime_CompilerServices_Unsafe_dll,
	&assembly_bundle_Unity_Abstractions_dll,
	&assembly_bundle_Unity_Container_dll,
	&assembly_bundle_weekysoft_store_dll,
	&assembly_bundle_Xamarin_Android_Arch_Core_Common_dll,
	&assembly_bundle_Xamarin_Android_Arch_Lifecycle_Common_dll,
	&assembly_bundle_Xamarin_Android_Arch_Lifecycle_Runtime_dll,
	&assembly_bundle_Xamarin_Android_Support_Animated_Vector_Drawable_dll,
	&assembly_bundle_Xamarin_Android_Support_Annotations_dll,
	&assembly_bundle_Xamarin_Android_Support_Compat_dll,
	&assembly_bundle_Xamarin_Android_Support_Core_UI_dll,
	&assembly_bundle_Xamarin_Android_Support_Core_Utils_dll,
	&assembly_bundle_Xamarin_Android_Support_Design_dll,
	&assembly_bundle_Xamarin_Android_Support_Fragment_dll,
	&assembly_bundle_Xamarin_Android_Support_Media_Compat_dll,
	&assembly_bundle_Xamarin_Android_Support_Transition_dll,
	&assembly_bundle_Xamarin_Android_Support_v4_dll,
	&assembly_bundle_Xamarin_Android_Support_v7_AppCompat_dll,
	&assembly_bundle_Xamarin_Android_Support_v7_CardView_dll,
	&assembly_bundle_Xamarin_Android_Support_v7_MediaRouter_dll,
	&assembly_bundle_Xamarin_Android_Support_v7_Palette_dll,
	&assembly_bundle_Xamarin_Android_Support_v7_RecyclerView_dll,
	&assembly_bundle_Xamarin_Android_Support_Vector_Drawable_dll,
	&assembly_bundle_Xamarin_Forms_Core_dll,
	&assembly_bundle_Xamarin_Forms_Platform_Android_dll,
	&assembly_bundle_Xamarin_Forms_Platform_dll,
	&assembly_bundle_Xamarin_Forms_Xaml_dll,
	&assembly_bundle_Java_Interop_dll,
	&assembly_bundle_Microsoft_CSharp_dll,
	&assembly_bundle_Mono_Android_dll,
	&assembly_bundle_mscorlib_dll,
	&assembly_bundle_System_Core_dll,
	&assembly_bundle_System_dll,
	&assembly_bundle_System_Xml_dll,
	&assembly_bundle_System_Xml_Linq_dll,
	&assembly_bundle_System_Reflection_TypeExtensions_dll,
	&assembly_bundle_System_Data_dll,
	&assembly_bundle_System_Numerics_dll,
	&assembly_bundle_System_Transactions_dll,
	&assembly_bundle_System_Net_Http_dll,
	&assembly_bundle_System_Runtime_Serialization_dll,
	&assembly_bundle_System_ServiceModel_Internals_dll,
	&assembly_bundle_System_ComponentModel_DataAnnotations_dll,
	&assembly_bundle_Mono_Security_dll,
	NULL
};


static void install_aot_modules (void) {

	mono_jit_set_aot_mode_ptr (MONO_AOT_MODE_NORMAL);

}

static char *image_name = "MTP.Android.dll";

static void install_dll_config_files (void (register_config_for_assembly_func)(const char *, const char *)) {

}

static const char *config_dir = NULL;
static MonoBundledAssembly **bundled;

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <zlib.h>

static int
my_inflate (const Byte *compr, uLong compr_len, Byte *uncompr, uLong uncompr_len)
{
	int err;
	z_stream stream;

	memset (&stream, 0, sizeof (z_stream));
	stream.next_in = (Byte *) compr;
	stream.avail_in = (uInt) compr_len;

	// http://www.zlib.net/manual.html
	err = inflateInit2 (&stream, 16+MAX_WBITS);
	if (err != Z_OK)
		return 1;

	for (;;) {
		stream.next_out = uncompr;
		stream.avail_out = (uInt) uncompr_len;
		err = inflate (&stream, Z_NO_FLUSH);
		if (err == Z_STREAM_END) break;
		if (err != Z_OK) {
			printf ("%d\n", err);
			return 2;
		}
	}

	err = inflateEnd (&stream);
	if (err != Z_OK)
		return 3;

	if (stream.total_out != uncompr_len)
		return 4;
	
	return 0;
}

void mono_mkbundle_init (void (register_bundled_assemblies_func)(const MonoBundledAssembly **), void (register_config_for_assembly_func)(const char *, const char *), void (mono_jit_set_aot_mode_func) (int mode))
{
	CompressedAssembly **ptr;
	MonoBundledAssembly **bundled_ptr;
	Bytef *buffer;
	int nbundles;

	mono_jit_set_aot_mode_ptr = mono_jit_set_aot_mode_func;

	install_dll_config_files (register_config_for_assembly_func);

	ptr = (CompressedAssembly **) compressed;
	nbundles = 0;
	while (*ptr++ != NULL)
		nbundles++;

	bundled = (MonoBundledAssembly **) malloc (sizeof (MonoBundledAssembly *) * (nbundles + 1));
	bundled_ptr = bundled;
	ptr = (CompressedAssembly **) compressed;
	while (*ptr != NULL) {
		uLong real_size;
		uLongf zsize;
		int result;
		MonoBundledAssembly *current;

		real_size = (*ptr)->assembly.size;
		zsize = (*ptr)->compressed_size;
		buffer = (Bytef *) malloc (real_size);
		result = my_inflate ((*ptr)->assembly.data, zsize, buffer, real_size);
		if (result != 0) {
			fprintf (stderr, "mkbundle: Error %d decompressing data for %s\n", result, (*ptr)->assembly.name);
			exit (1);
		}
		(*ptr)->assembly.data = buffer;
		current = (MonoBundledAssembly *) malloc (sizeof (MonoBundledAssembly));
		memcpy (current, *ptr, sizeof (MonoBundledAssembly));
		current->name = (*ptr)->assembly.name;
		*bundled_ptr = current;
		bundled_ptr++;
		ptr++;
	}
	*bundled_ptr = NULL;
	register_bundled_assemblies_func((const MonoBundledAssembly **) bundled);
}
