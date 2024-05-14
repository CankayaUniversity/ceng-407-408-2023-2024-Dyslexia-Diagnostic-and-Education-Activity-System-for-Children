; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [331 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [656 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 250
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 284
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 38948123, ; 6: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 292
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 201
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42244203, ; 9: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 301
	i32 42639949, ; 10: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 325
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 199
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 83839681, ; 16: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 309
	i32 98325684, ; 17: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 186
	i32 101534019, ; 18: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 268
	i32 117431740, ; 19: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 20: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 268
	i32 122350210, ; 21: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 22: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 288
	i32 136584136, ; 23: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 324
	i32 140062828, ; 24: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 317
	i32 142721839, ; 25: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 26: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 27: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 28: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 224
	i32 175859233, ; 29: DyslexiaAppMAUI.Shared => 0xa7b6621 => 326
	i32 176265551, ; 30: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 31: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 270
	i32 184328833, ; 32: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 33: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 34: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 222
	i32 220171995, ; 35: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 221958352, ; 36: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 185
	i32 230216969, ; 37: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 244
	i32 230752869, ; 38: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 39: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 40: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 41: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 42: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 227
	i32 276479776, ; 43: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 277295747, ; 44: Refit.HttpClientFactory => 0x10873283 => 203
	i32 278686392, ; 45: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 246
	i32 280482487, ; 46: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 243
	i32 291076382, ; 47: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 291275502, ; 48: Microsoft.Extensions.Http.dll => 0x115c82ee => 187
	i32 298918909, ; 49: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 50: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 322
	i32 318968648, ; 51: Xamarin.AndroidX.Activity.dll => 0x13031348 => 213
	i32 321597661, ; 52: System.Numerics => 0x132b30dd => 83
	i32 321963286, ; 53: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 300
	i32 342366114, ; 54: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 245
	i32 360082299, ; 55: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 56: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 57: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 58: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 59: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 60: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 61: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 62: _Microsoft.Android.Resource.Designer => 0x17969339 => 327
	i32 403441872, ; 63: WindowsBase => 0x180c08d0 => 165
	i32 409257351, ; 64: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 320
	i32 441335492, ; 65: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 228
	i32 442565967, ; 66: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 67: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 241
	i32 451504562, ; 68: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 69: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 70: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 71: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 72: System.dll => 0x1bff388e => 164
	i32 476646585, ; 73: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 243
	i32 486930444, ; 74: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 256
	i32 489220957, ; 75: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 298
	i32 498788369, ; 76: System.ObjectModel => 0x1dbae811 => 84
	i32 513247710, ; 77: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 193
	i32 526420162, ; 78: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 79: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 288
	i32 530272170, ; 80: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 538707440, ; 81: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 319
	i32 539058512, ; 82: Microsoft.Extensions.Logging => 0x20216150 => 188
	i32 540030774, ; 83: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 84: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 85: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 86: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 87: Jsr305Binding => 0x213954e7 => 281
	i32 569601784, ; 88: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 279
	i32 577335427, ; 89: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 586578074, ; 90: MimeKit => 0x22f6789a => 200
	i32 601371474, ; 91: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 92: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 93: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 94: Xamarin.AndroidX.CustomView => 0x2568904f => 233
	i32 627931235, ; 95: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 311
	i32 639843206, ; 96: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 239
	i32 643868501, ; 97: System.Net => 0x2660a755 => 81
	i32 662205335, ; 98: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 99: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 275
	i32 666292255, ; 100: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 220
	i32 672442732, ; 101: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 102: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 103: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 104: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 290
	i32 693804605, ; 105: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 106: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 107: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 285
	i32 700358131, ; 108: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 709152836, ; 109: System.Security.Cryptography.Pkcs.dll => 0x2a44d044 => 208
	i32 720511267, ; 110: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 289
	i32 722857257, ; 111: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 731701662, ; 112: Microsoft.Extensions.Options.ConfigurationExtensions => 0x2b9ce19e => 192
	i32 734124578, ; 113: Google.Apis.Gmail.v1 => 0x2bc1da22 => 178
	i32 735137430, ; 114: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 115: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 116: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 210
	i32 759454413, ; 117: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 118: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 119: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 120: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 317
	i32 789151979, ; 121: Microsoft.Extensions.Options => 0x2f0980eb => 191
	i32 790371945, ; 122: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 234
	i32 804715423, ; 123: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 124: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 248
	i32 823281589, ; 125: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 126: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 127: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 128: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 129: Xamarin.AndroidX.Print => 0x3246f6cd => 261
	i32 869139383, ; 130: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 302
	i32 873119928, ; 131: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 132: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 133: System.Net.Http.Json => 0x3463c971 => 63
	i32 880668424, ; 134: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 316
	i32 904024072, ; 135: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 908337989, ; 136: Refit => 0x36242345 => 202
	i32 911108515, ; 137: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 918734561, ; 138: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 313
	i32 928116545, ; 139: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 284
	i32 952186615, ; 140: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 141: Newtonsoft.Json => 0x38f24a24 => 201
	i32 956575887, ; 142: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 289
	i32 961460050, ; 143: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 306
	i32 966729478, ; 144: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 282
	i32 967690846, ; 145: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 245
	i32 975236339, ; 146: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 147: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 148: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 149: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 990727110, ; 150: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 315
	i32 992768348, ; 151: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 152: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 153: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 154: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 265
	i32 1019214401, ; 155: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 156: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 184
	i32 1031528504, ; 157: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 283
	i32 1035644815, ; 158: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 218
	i32 1036536393, ; 159: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1043950537, ; 160: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 296
	i32 1044663988, ; 161: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048992957, ; 162: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 186
	i32 1052210849, ; 163: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 252
	i32 1067306892, ; 164: GoogleGson => 0x3f9dcf8c => 179
	i32 1082857460, ; 165: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 166: Xamarin.Kotlin.StdLib => 0x409e66d8 => 286
	i32 1098259244, ; 167: System => 0x41761b2c => 164
	i32 1108272742, ; 168: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 318
	i32 1117529484, ; 169: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 312
	i32 1118262833, ; 170: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 308
	i32 1121599056, ; 171: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 251
	i32 1122549021, ; 172: Refit.HttpClientFactory.dll => 0x42e8bd1d => 203
	i32 1127624469, ; 173: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 190
	i32 1149092582, ; 174: Xamarin.AndroidX.Window => 0x447dc2e6 => 278
	i32 1168523401, ; 175: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 314
	i32 1170634674, ; 176: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 177: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 274
	i32 1178241025, ; 178: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 259
	i32 1201029973, ; 179: StarkbankEcdsa => 0x47964355 => 205
	i32 1204270330, ; 180: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 220
	i32 1208641965, ; 181: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1214827643, ; 182: CommunityToolkit.Mvvm => 0x4868cc7b => 174
	i32 1219128291, ; 183: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1243150071, ; 184: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 279
	i32 1251888248, ; 185: DyslexiaAppMAUI.Shared.dll => 0x4a9e4c78 => 326
	i32 1253011324, ; 186: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 187: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 294
	i32 1264511973, ; 188: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 269
	i32 1267360935, ; 189: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 273
	i32 1273260888, ; 190: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 225
	i32 1275534314, ; 191: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 290
	i32 1278448581, ; 192: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 217
	i32 1293217323, ; 193: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 236
	i32 1308624726, ; 194: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 303
	i32 1309188875, ; 195: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 196: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 278
	i32 1324164729, ; 197: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 198: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1336711579, ; 199: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 323
	i32 1364015309, ; 200: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 201: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 324
	i32 1376866003, ; 202: Xamarin.AndroidX.SavedState => 0x52114ed3 => 265
	i32 1379779777, ; 203: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 204: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 205: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 229
	i32 1408764838, ; 206: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 207: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 208: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 209: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 292
	i32 1433687999, ; 210: SendGrid.dll => 0x557457bf => 204
	i32 1434145427, ; 211: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 212: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 282
	i32 1439761251, ; 213: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 214: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 215: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 216: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 217: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 218: es\Microsoft.Maui.Controls.resources => 0x57152abe => 298
	i32 1461234159, ; 219: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 220: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 221: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 222: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 219
	i32 1470490898, ; 223: Microsoft.Extensions.Primitives => 0x57a5e912 => 193
	i32 1479771757, ; 224: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 225: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 226: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 227: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 266
	i32 1505131794, ; 228: Microsoft.Extensions.Http => 0x59b67d12 => 187
	i32 1526286932, ; 229: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 322
	i32 1536373174, ; 230: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 231: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 232: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 233: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 234: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 235: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 236: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 237: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 238: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 235
	i32 1592978981, ; 239: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 240: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 283
	i32 1601112923, ; 241: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 242: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 243: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 244: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 255
	i32 1622358360, ; 245: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 246: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 277
	i32 1635184631, ; 247: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 239
	i32 1636350590, ; 248: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 232
	i32 1639515021, ; 249: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 250: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 251: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 252: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 253: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 271
	i32 1658251792, ; 254: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 280
	i32 1670060433, ; 255: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 227
	i32 1675553242, ; 256: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 257: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 258: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 259: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 260: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 261: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 262: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 287
	i32 1701541528, ; 263: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 264: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 248
	i32 1726116996, ; 265: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 266: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 267: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 223
	i32 1743415430, ; 268: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 293
	i32 1744735666, ; 269: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 270: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 271: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 272: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 273: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 274: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 275: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 270
	i32 1770582343, ; 276: Microsoft.Extensions.Logging.dll => 0x6988f147 => 188
	i32 1776026572, ; 277: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 278: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 279: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 280: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 309
	i32 1788241197, ; 281: Xamarin.AndroidX.Fragment => 0x6a96652d => 241
	i32 1793755602, ; 282: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 301
	i32 1808609942, ; 283: Xamarin.AndroidX.Loader => 0x6bcd3296 => 255
	i32 1813058853, ; 284: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 286
	i32 1813201214, ; 285: Xamarin.Google.Android.Material => 0x6c13413e => 280
	i32 1818569960, ; 286: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 260
	i32 1818787751, ; 287: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 288: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 289: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 290: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 189
	i32 1847515442, ; 291: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 210
	i32 1853025655, ; 292: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 318
	i32 1858542181, ; 293: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 294: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 295: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 300
	i32 1879696579, ; 296: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 297: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 221
	i32 1888955245, ; 298: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 299: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1893218855, ; 300: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 294
	i32 1898237753, ; 301: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 302: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 303: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1927897671, ; 304: System.CodeDom.dll => 0x72e96247 => 206
	i32 1939592360, ; 305: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1953182387, ; 306: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 305
	i32 1956758971, ; 307: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 308: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 267
	i32 1968388702, ; 309: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 180
	i32 1983156543, ; 310: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 287
	i32 1985761444, ; 311: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 212
	i32 2003115576, ; 312: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 297
	i32 2004041166, ; 313: Google.Apis.Gmail.v1.dll => 0x77733dce => 178
	i32 2011961780, ; 314: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 315: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 252
	i32 2031763787, ; 316: Xamarin.Android.Glide => 0x791a414b => 209
	i32 2045470958, ; 317: System.Private.Xml => 0x79eb68ee => 88
	i32 2048278909, ; 318: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 182
	i32 2055257422, ; 319: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 247
	i32 2060060697, ; 320: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 321: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 296
	i32 2070888862, ; 322: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 323: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 324: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 325: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 326: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 327: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 328: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 329: Microsoft.Maui => 0x80bd55ad => 197
	i32 2169148018, ; 330: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 304
	i32 2178612968, ; 331: System.CodeDom => 0x81dafee8 => 206
	i32 2181898931, ; 332: Microsoft.Extensions.Options.dll => 0x820d22b3 => 191
	i32 2192057212, ; 333: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 189
	i32 2193016926, ; 334: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 335: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 291
	i32 2201231467, ; 336: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 337: it\Microsoft.Maui.Controls.resources => 0x839595db => 306
	i32 2210798277, ; 338: SendGrid => 0x83c61ac5 => 204
	i32 2217644978, ; 339: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 274
	i32 2222056684, ; 340: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 341: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 256
	i32 2252106437, ; 342: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 343: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 344: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 345: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 181
	i32 2267999099, ; 346: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 211
	i32 2279755925, ; 347: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 263
	i32 2293034957, ; 348: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 349: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 350: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 351: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 310
	i32 2305521784, ; 352: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 353: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 215
	i32 2320631194, ; 354: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 355: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 356: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 357: System.Net.Primitives => 0x8c40e0db => 70
	i32 2366048013, ; 358: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 304
	i32 2368005991, ; 359: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 360: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 180
	i32 2378619854, ; 361: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 362: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 363: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 305
	i32 2401565422, ; 364: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 365: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 238
	i32 2421380589, ; 366: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 367: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 225
	i32 2427813419, ; 368: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 302
	i32 2435356389, ; 369: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 370: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 371: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 372: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 373: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 374: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 228
	i32 2471841756, ; 375: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 376: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 377: Microsoft.Maui.Controls => 0x93dba8a1 => 195
	i32 2483903535, ; 378: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 379: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 380: System.AppContext.dll => 0x94798bc5 => 6
	i32 2498657740, ; 381: BouncyCastle.Cryptography.dll => 0x94ee7dcc => 173
	i32 2501346920, ; 382: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2503351294, ; 383: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 308
	i32 2505896520, ; 384: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 250
	i32 2522472828, ; 385: Xamarin.Android.Glide.dll => 0x9659e17c => 209
	i32 2538310050, ; 386: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 387: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 303
	i32 2562349572, ; 388: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 389: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2576534780, ; 390: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 307
	i32 2581783588, ; 391: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 251
	i32 2581819634, ; 392: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 273
	i32 2585220780, ; 393: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 394: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 395: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 396: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 312
	i32 2605712449, ; 397: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 291
	i32 2615233544, ; 398: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 242
	i32 2616218305, ; 399: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 190
	i32 2617129537, ; 400: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 401: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 402: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 232
	i32 2624644809, ; 403: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 237
	i32 2626831493, ; 404: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 307
	i32 2627185994, ; 405: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 406: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 407: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 246
	i32 2663391936, ; 408: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 211
	i32 2663698177, ; 409: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 410: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 411: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 412: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 413: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 414: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 415: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 271
	i32 2715334215, ; 416: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 417: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 418: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 419: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 420: Xamarin.AndroidX.Activity => 0xa2e0939b => 213
	i32 2735172069, ; 421: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 422: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 219
	i32 2740698338, ; 423: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 293
	i32 2740948882, ; 424: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 425: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 426: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 313
	i32 2758225723, ; 427: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 196
	i32 2764765095, ; 428: Microsoft.Maui.dll => 0xa4caf7a7 => 197
	i32 2765824710, ; 429: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 430: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 285
	i32 2778768386, ; 431: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 276
	i32 2779977773, ; 432: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 264
	i32 2785988530, ; 433: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 319
	i32 2788224221, ; 434: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 242
	i32 2801831435, ; 435: Microsoft.Maui.Graphics => 0xa7008e0b => 199
	i32 2803228030, ; 436: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 437: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 229
	i32 2819470561, ; 438: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 439: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 440: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 264
	i32 2824502124, ; 441: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2838993487, ; 442: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 253
	i32 2849599387, ; 443: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 444: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 276
	i32 2855708567, ; 445: Xamarin.AndroidX.Transition => 0xaa36a797 => 272
	i32 2861098320, ; 446: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 447: Microsoft.Maui.Essentials => 0xaa8a4878 => 198
	i32 2870099610, ; 448: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 214
	i32 2875164099, ; 449: Jsr305Binding.dll => 0xab5f85c3 => 281
	i32 2875220617, ; 450: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 451: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 240
	i32 2887636118, ; 452: System.Net.dll => 0xac1dd496 => 81
	i32 2893550578, ; 453: Google.Apis.Core => 0xac7813f2 => 177
	i32 2898407901, ; 454: System.Management => 0xacc231dd => 207
	i32 2899753641, ; 455: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 456: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 457: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 458: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 459: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 460: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 277
	i32 2919462931, ; 461: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 462: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 216
	i32 2936416060, ; 463: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 464: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 465: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 466: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 467: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2971004615, ; 468: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0xb115eec7 => 192
	i32 2972252294, ; 469: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 470: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 236
	i32 2980486542, ; 471: DyslexiaApp.MAUI => 0xb1a69d8e => 0
	i32 2987532451, ; 472: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 267
	i32 2990604888, ; 473: Google.Apis => 0xb2410258 => 175
	i32 2996846495, ; 474: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 249
	i32 3016983068, ; 475: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 269
	i32 3020703001, ; 476: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 185
	i32 3023353419, ; 477: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 478: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 244
	i32 3038032645, ; 479: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 327
	i32 3053864966, ; 480: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 299
	i32 3056245963, ; 481: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 266
	i32 3057625584, ; 482: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 257
	i32 3059408633, ; 483: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 484: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 485: System.Threading.Tasks => 0xb755818f => 144
	i32 3090735792, ; 486: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 487: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 488: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 489: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 490: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 491: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 492: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 493: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 494: GoogleGson.dll => 0xbba64c02 => 179
	i32 3159123045, ; 495: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 496: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3171180504, ; 497: MimeKit.dll => 0xbd045fd8 => 200
	i32 3178803400, ; 498: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 258
	i32 3192346100, ; 499: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 500: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 501: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 502: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 503: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 235
	i32 3220365878, ; 504: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 505: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 506: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 507: Xamarin.AndroidX.CardView => 0xc235e84d => 223
	i32 3265493905, ; 508: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 509: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3271840132, ; 510: StarkbankEcdsa.dll => 0xc3045184 => 205
	i32 3277815716, ; 511: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 512: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 513: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 514: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 515: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 516: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 517: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 299
	i32 3316684772, ; 518: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 519: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 233
	i32 3317144872, ; 520: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 521: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 221
	i32 3345895724, ; 522: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 262
	i32 3346324047, ; 523: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 259
	i32 3357674450, ; 524: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 316
	i32 3358260929, ; 525: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 526: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 214
	i32 3362522851, ; 527: Xamarin.AndroidX.Core => 0xc86c06e3 => 230
	i32 3366347497, ; 528: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 529: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 263
	i32 3381016424, ; 530: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 295
	i32 3395150330, ; 531: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 532: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 533: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 234
	i32 3421170118, ; 534: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 182
	i32 3428513518, ; 535: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 183
	i32 3429136800, ; 536: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 537: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 538: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 237
	i32 3445260447, ; 539: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 540: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 194
	i32 3453592554, ; 541: Google.Apis.Core.dll => 0xcdd9a3ea => 177
	i32 3458724246, ; 542: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 314
	i32 3471940407, ; 543: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 544: Mono.Android => 0xcf3163e6 => 171
	i32 3484440000, ; 545: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 315
	i32 3485117614, ; 546: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 547: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 548: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 226
	i32 3509114376, ; 549: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 550: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 551: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 552: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 553: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 554: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 555: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 323
	i32 3592228221, ; 556: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 325
	i32 3597029428, ; 557: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 212
	i32 3598340787, ; 558: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3605570793, ; 559: BouncyCastle.Cryptography => 0xd6e8a4e9 => 173
	i32 3608519521, ; 560: System.Linq.dll => 0xd715a361 => 61
	i32 3612435020, ; 561: System.Management.dll => 0xd751624c => 207
	i32 3624195450, ; 562: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 563: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 261
	i32 3633644679, ; 564: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 216
	i32 3638274909, ; 565: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 566: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 247
	i32 3643446276, ; 567: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 320
	i32 3643854240, ; 568: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 258
	i32 3645089577, ; 569: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 570: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 181
	i32 3660523487, ; 571: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 572: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 573: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 222
	i32 3684561358, ; 574: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 226
	i32 3700866549, ; 575: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 576: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 231
	i32 3716563718, ; 577: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 578: Xamarin.AndroidX.Annotation => 0xdda814c6 => 215
	i32 3724971120, ; 579: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 257
	i32 3732100267, ; 580: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 581: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 582: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 583: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3751619990, ; 584: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 295
	i32 3786282454, ; 585: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 224
	i32 3792276235, ; 586: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3793997468, ; 587: Google.Apis.Auth.dll => 0xe223ce9c => 176
	i32 3800979733, ; 588: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 194
	i32 3802395368, ; 589: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3807198597, ; 590: System.Security.Cryptography.Pkcs => 0xe2ed3d85 => 208
	i32 3819260425, ; 591: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 592: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 593: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 594: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 184
	i32 3844307129, ; 595: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 596: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3863245636, ; 597: DyslexiaApp.MAUI.dll => 0xe6447344 => 0
	i32 3870376305, ; 598: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 599: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 600: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 601: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 602: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 272
	i32 3888767677, ; 603: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 262
	i32 3896106733, ; 604: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 605: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 230
	i32 3901907137, ; 606: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920221145, ; 607: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 311
	i32 3920810846, ; 608: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 609: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 275
	i32 3928044579, ; 610: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 611: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 612: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 260
	i32 3945713374, ; 613: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 614: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 615: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 218
	i32 3959773229, ; 616: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 249
	i32 4003436829, ; 617: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 618: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 217
	i32 4025784931, ; 619: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 620: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 196
	i32 4054681211, ; 621: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4059682726, ; 622: Google.Apis.dll => 0xf1f9d7a6 => 175
	i32 4068434129, ; 623: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 624: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4082882467, ; 625: Google.Apis.Auth => 0xf35bd7a3 => 176
	i32 4091086043, ; 626: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 297
	i32 4094352644, ; 627: Microsoft.Maui.Essentials.dll => 0xf40add04 => 198
	i32 4099507663, ; 628: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 629: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 630: Xamarin.AndroidX.Emoji2 => 0xf479582c => 238
	i32 4103439459, ; 631: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 321
	i32 4126470640, ; 632: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 183
	i32 4127667938, ; 633: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 634: System.AppContext => 0xf6318da0 => 6
	i32 4144683026, ; 635: Refit.dll => 0xf70ad812 => 202
	i32 4147896353, ; 636: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 637: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 321
	i32 4151237749, ; 638: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 639: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 640: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 641: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 642: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 643: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 254
	i32 4185676441, ; 644: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 645: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 646: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4249188766, ; 647: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 310
	i32 4256097574, ; 648: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 231
	i32 4258378803, ; 649: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 253
	i32 4260525087, ; 650: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 651: Microsoft.Maui.Controls.dll => 0xfea12dee => 195
	i32 4274623895, ; 652: CommunityToolkit.Mvvm.dll => 0xfec99597 => 174
	i32 4274976490, ; 653: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 654: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 254
	i32 4294763496 ; 655: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 240
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [656 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 250, ; 3
	i32 284, ; 4
	i32 48, ; 5
	i32 292, ; 6
	i32 201, ; 7
	i32 80, ; 8
	i32 301, ; 9
	i32 145, ; 10
	i32 30, ; 11
	i32 325, ; 12
	i32 124, ; 13
	i32 199, ; 14
	i32 102, ; 15
	i32 309, ; 16
	i32 186, ; 17
	i32 268, ; 18
	i32 107, ; 19
	i32 268, ; 20
	i32 139, ; 21
	i32 288, ; 22
	i32 324, ; 23
	i32 317, ; 24
	i32 77, ; 25
	i32 124, ; 26
	i32 13, ; 27
	i32 224, ; 28
	i32 326, ; 29
	i32 132, ; 30
	i32 270, ; 31
	i32 151, ; 32
	i32 18, ; 33
	i32 222, ; 34
	i32 26, ; 35
	i32 185, ; 36
	i32 244, ; 37
	i32 1, ; 38
	i32 59, ; 39
	i32 42, ; 40
	i32 91, ; 41
	i32 227, ; 42
	i32 147, ; 43
	i32 203, ; 44
	i32 246, ; 45
	i32 243, ; 46
	i32 54, ; 47
	i32 187, ; 48
	i32 69, ; 49
	i32 322, ; 50
	i32 213, ; 51
	i32 83, ; 52
	i32 300, ; 53
	i32 245, ; 54
	i32 131, ; 55
	i32 55, ; 56
	i32 149, ; 57
	i32 74, ; 58
	i32 145, ; 59
	i32 62, ; 60
	i32 146, ; 61
	i32 327, ; 62
	i32 165, ; 63
	i32 320, ; 64
	i32 228, ; 65
	i32 12, ; 66
	i32 241, ; 67
	i32 125, ; 68
	i32 152, ; 69
	i32 113, ; 70
	i32 166, ; 71
	i32 164, ; 72
	i32 243, ; 73
	i32 256, ; 74
	i32 298, ; 75
	i32 84, ; 76
	i32 193, ; 77
	i32 150, ; 78
	i32 288, ; 79
	i32 60, ; 80
	i32 319, ; 81
	i32 188, ; 82
	i32 51, ; 83
	i32 103, ; 84
	i32 114, ; 85
	i32 40, ; 86
	i32 281, ; 87
	i32 279, ; 88
	i32 120, ; 89
	i32 200, ; 90
	i32 52, ; 91
	i32 44, ; 92
	i32 119, ; 93
	i32 233, ; 94
	i32 311, ; 95
	i32 239, ; 96
	i32 81, ; 97
	i32 136, ; 98
	i32 275, ; 99
	i32 220, ; 100
	i32 8, ; 101
	i32 73, ; 102
	i32 155, ; 103
	i32 290, ; 104
	i32 154, ; 105
	i32 92, ; 106
	i32 285, ; 107
	i32 45, ; 108
	i32 208, ; 109
	i32 289, ; 110
	i32 109, ; 111
	i32 192, ; 112
	i32 178, ; 113
	i32 129, ; 114
	i32 25, ; 115
	i32 210, ; 116
	i32 72, ; 117
	i32 55, ; 118
	i32 46, ; 119
	i32 317, ; 120
	i32 191, ; 121
	i32 234, ; 122
	i32 22, ; 123
	i32 248, ; 124
	i32 86, ; 125
	i32 43, ; 126
	i32 160, ; 127
	i32 71, ; 128
	i32 261, ; 129
	i32 302, ; 130
	i32 3, ; 131
	i32 42, ; 132
	i32 63, ; 133
	i32 316, ; 134
	i32 16, ; 135
	i32 202, ; 136
	i32 53, ; 137
	i32 313, ; 138
	i32 284, ; 139
	i32 105, ; 140
	i32 201, ; 141
	i32 289, ; 142
	i32 306, ; 143
	i32 282, ; 144
	i32 245, ; 145
	i32 34, ; 146
	i32 158, ; 147
	i32 85, ; 148
	i32 32, ; 149
	i32 315, ; 150
	i32 12, ; 151
	i32 51, ; 152
	i32 56, ; 153
	i32 265, ; 154
	i32 36, ; 155
	i32 184, ; 156
	i32 283, ; 157
	i32 218, ; 158
	i32 35, ; 159
	i32 296, ; 160
	i32 58, ; 161
	i32 186, ; 162
	i32 252, ; 163
	i32 179, ; 164
	i32 17, ; 165
	i32 286, ; 166
	i32 164, ; 167
	i32 318, ; 168
	i32 312, ; 169
	i32 308, ; 170
	i32 251, ; 171
	i32 203, ; 172
	i32 190, ; 173
	i32 278, ; 174
	i32 314, ; 175
	i32 153, ; 176
	i32 274, ; 177
	i32 259, ; 178
	i32 205, ; 179
	i32 220, ; 180
	i32 29, ; 181
	i32 174, ; 182
	i32 52, ; 183
	i32 279, ; 184
	i32 326, ; 185
	i32 5, ; 186
	i32 294, ; 187
	i32 269, ; 188
	i32 273, ; 189
	i32 225, ; 190
	i32 290, ; 191
	i32 217, ; 192
	i32 236, ; 193
	i32 303, ; 194
	i32 85, ; 195
	i32 278, ; 196
	i32 61, ; 197
	i32 112, ; 198
	i32 323, ; 199
	i32 57, ; 200
	i32 324, ; 201
	i32 265, ; 202
	i32 99, ; 203
	i32 19, ; 204
	i32 229, ; 205
	i32 111, ; 206
	i32 101, ; 207
	i32 102, ; 208
	i32 292, ; 209
	i32 204, ; 210
	i32 104, ; 211
	i32 282, ; 212
	i32 71, ; 213
	i32 38, ; 214
	i32 32, ; 215
	i32 103, ; 216
	i32 73, ; 217
	i32 298, ; 218
	i32 9, ; 219
	i32 123, ; 220
	i32 46, ; 221
	i32 219, ; 222
	i32 193, ; 223
	i32 9, ; 224
	i32 43, ; 225
	i32 4, ; 226
	i32 266, ; 227
	i32 187, ; 228
	i32 322, ; 229
	i32 31, ; 230
	i32 138, ; 231
	i32 92, ; 232
	i32 93, ; 233
	i32 49, ; 234
	i32 141, ; 235
	i32 112, ; 236
	i32 140, ; 237
	i32 235, ; 238
	i32 115, ; 239
	i32 283, ; 240
	i32 157, ; 241
	i32 76, ; 242
	i32 79, ; 243
	i32 255, ; 244
	i32 37, ; 245
	i32 277, ; 246
	i32 239, ; 247
	i32 232, ; 248
	i32 64, ; 249
	i32 138, ; 250
	i32 15, ; 251
	i32 116, ; 252
	i32 271, ; 253
	i32 280, ; 254
	i32 227, ; 255
	i32 48, ; 256
	i32 70, ; 257
	i32 80, ; 258
	i32 126, ; 259
	i32 94, ; 260
	i32 121, ; 261
	i32 287, ; 262
	i32 26, ; 263
	i32 248, ; 264
	i32 97, ; 265
	i32 28, ; 266
	i32 223, ; 267
	i32 293, ; 268
	i32 149, ; 269
	i32 169, ; 270
	i32 4, ; 271
	i32 98, ; 272
	i32 33, ; 273
	i32 93, ; 274
	i32 270, ; 275
	i32 188, ; 276
	i32 21, ; 277
	i32 41, ; 278
	i32 170, ; 279
	i32 309, ; 280
	i32 241, ; 281
	i32 301, ; 282
	i32 255, ; 283
	i32 286, ; 284
	i32 280, ; 285
	i32 260, ; 286
	i32 2, ; 287
	i32 134, ; 288
	i32 111, ; 289
	i32 189, ; 290
	i32 210, ; 291
	i32 318, ; 292
	i32 58, ; 293
	i32 95, ; 294
	i32 300, ; 295
	i32 39, ; 296
	i32 221, ; 297
	i32 25, ; 298
	i32 94, ; 299
	i32 294, ; 300
	i32 89, ; 301
	i32 99, ; 302
	i32 10, ; 303
	i32 206, ; 304
	i32 87, ; 305
	i32 305, ; 306
	i32 100, ; 307
	i32 267, ; 308
	i32 180, ; 309
	i32 287, ; 310
	i32 212, ; 311
	i32 297, ; 312
	i32 178, ; 313
	i32 7, ; 314
	i32 252, ; 315
	i32 209, ; 316
	i32 88, ; 317
	i32 182, ; 318
	i32 247, ; 319
	i32 154, ; 320
	i32 296, ; 321
	i32 33, ; 322
	i32 116, ; 323
	i32 82, ; 324
	i32 20, ; 325
	i32 11, ; 326
	i32 162, ; 327
	i32 3, ; 328
	i32 197, ; 329
	i32 304, ; 330
	i32 206, ; 331
	i32 191, ; 332
	i32 189, ; 333
	i32 84, ; 334
	i32 291, ; 335
	i32 64, ; 336
	i32 306, ; 337
	i32 204, ; 338
	i32 274, ; 339
	i32 143, ; 340
	i32 256, ; 341
	i32 157, ; 342
	i32 41, ; 343
	i32 117, ; 344
	i32 181, ; 345
	i32 211, ; 346
	i32 263, ; 347
	i32 131, ; 348
	i32 75, ; 349
	i32 66, ; 350
	i32 310, ; 351
	i32 172, ; 352
	i32 215, ; 353
	i32 143, ; 354
	i32 106, ; 355
	i32 151, ; 356
	i32 70, ; 357
	i32 304, ; 358
	i32 156, ; 359
	i32 180, ; 360
	i32 121, ; 361
	i32 127, ; 362
	i32 305, ; 363
	i32 152, ; 364
	i32 238, ; 365
	i32 141, ; 366
	i32 225, ; 367
	i32 302, ; 368
	i32 20, ; 369
	i32 14, ; 370
	i32 135, ; 371
	i32 75, ; 372
	i32 59, ; 373
	i32 228, ; 374
	i32 167, ; 375
	i32 168, ; 376
	i32 195, ; 377
	i32 15, ; 378
	i32 74, ; 379
	i32 6, ; 380
	i32 173, ; 381
	i32 23, ; 382
	i32 308, ; 383
	i32 250, ; 384
	i32 209, ; 385
	i32 91, ; 386
	i32 303, ; 387
	i32 1, ; 388
	i32 136, ; 389
	i32 307, ; 390
	i32 251, ; 391
	i32 273, ; 392
	i32 134, ; 393
	i32 69, ; 394
	i32 146, ; 395
	i32 312, ; 396
	i32 291, ; 397
	i32 242, ; 398
	i32 190, ; 399
	i32 88, ; 400
	i32 96, ; 401
	i32 232, ; 402
	i32 237, ; 403
	i32 307, ; 404
	i32 31, ; 405
	i32 45, ; 406
	i32 246, ; 407
	i32 211, ; 408
	i32 109, ; 409
	i32 158, ; 410
	i32 35, ; 411
	i32 22, ; 412
	i32 114, ; 413
	i32 57, ; 414
	i32 271, ; 415
	i32 144, ; 416
	i32 118, ; 417
	i32 120, ; 418
	i32 110, ; 419
	i32 213, ; 420
	i32 139, ; 421
	i32 219, ; 422
	i32 293, ; 423
	i32 54, ; 424
	i32 105, ; 425
	i32 313, ; 426
	i32 196, ; 427
	i32 197, ; 428
	i32 133, ; 429
	i32 285, ; 430
	i32 276, ; 431
	i32 264, ; 432
	i32 319, ; 433
	i32 242, ; 434
	i32 199, ; 435
	i32 159, ; 436
	i32 229, ; 437
	i32 163, ; 438
	i32 132, ; 439
	i32 264, ; 440
	i32 161, ; 441
	i32 253, ; 442
	i32 140, ; 443
	i32 276, ; 444
	i32 272, ; 445
	i32 169, ; 446
	i32 198, ; 447
	i32 214, ; 448
	i32 281, ; 449
	i32 40, ; 450
	i32 240, ; 451
	i32 81, ; 452
	i32 177, ; 453
	i32 207, ; 454
	i32 56, ; 455
	i32 37, ; 456
	i32 97, ; 457
	i32 166, ; 458
	i32 172, ; 459
	i32 277, ; 460
	i32 82, ; 461
	i32 216, ; 462
	i32 98, ; 463
	i32 30, ; 464
	i32 159, ; 465
	i32 18, ; 466
	i32 127, ; 467
	i32 192, ; 468
	i32 119, ; 469
	i32 236, ; 470
	i32 0, ; 471
	i32 267, ; 472
	i32 175, ; 473
	i32 249, ; 474
	i32 269, ; 475
	i32 185, ; 476
	i32 165, ; 477
	i32 244, ; 478
	i32 327, ; 479
	i32 299, ; 480
	i32 266, ; 481
	i32 257, ; 482
	i32 170, ; 483
	i32 16, ; 484
	i32 144, ; 485
	i32 125, ; 486
	i32 118, ; 487
	i32 38, ; 488
	i32 115, ; 489
	i32 47, ; 490
	i32 142, ; 491
	i32 117, ; 492
	i32 34, ; 493
	i32 179, ; 494
	i32 95, ; 495
	i32 53, ; 496
	i32 200, ; 497
	i32 258, ; 498
	i32 129, ; 499
	i32 153, ; 500
	i32 24, ; 501
	i32 161, ; 502
	i32 235, ; 503
	i32 148, ; 504
	i32 104, ; 505
	i32 89, ; 506
	i32 223, ; 507
	i32 60, ; 508
	i32 142, ; 509
	i32 205, ; 510
	i32 100, ; 511
	i32 5, ; 512
	i32 13, ; 513
	i32 122, ; 514
	i32 135, ; 515
	i32 28, ; 516
	i32 299, ; 517
	i32 72, ; 518
	i32 233, ; 519
	i32 24, ; 520
	i32 221, ; 521
	i32 262, ; 522
	i32 259, ; 523
	i32 316, ; 524
	i32 137, ; 525
	i32 214, ; 526
	i32 230, ; 527
	i32 168, ; 528
	i32 263, ; 529
	i32 295, ; 530
	i32 101, ; 531
	i32 123, ; 532
	i32 234, ; 533
	i32 182, ; 534
	i32 183, ; 535
	i32 163, ; 536
	i32 167, ; 537
	i32 237, ; 538
	i32 39, ; 539
	i32 194, ; 540
	i32 177, ; 541
	i32 314, ; 542
	i32 17, ; 543
	i32 171, ; 544
	i32 315, ; 545
	i32 137, ; 546
	i32 150, ; 547
	i32 226, ; 548
	i32 155, ; 549
	i32 130, ; 550
	i32 19, ; 551
	i32 65, ; 552
	i32 147, ; 553
	i32 47, ; 554
	i32 323, ; 555
	i32 325, ; 556
	i32 212, ; 557
	i32 79, ; 558
	i32 173, ; 559
	i32 61, ; 560
	i32 207, ; 561
	i32 106, ; 562
	i32 261, ; 563
	i32 216, ; 564
	i32 49, ; 565
	i32 247, ; 566
	i32 320, ; 567
	i32 258, ; 568
	i32 14, ; 569
	i32 181, ; 570
	i32 68, ; 571
	i32 171, ; 572
	i32 222, ; 573
	i32 226, ; 574
	i32 78, ; 575
	i32 231, ; 576
	i32 108, ; 577
	i32 215, ; 578
	i32 257, ; 579
	i32 67, ; 580
	i32 63, ; 581
	i32 27, ; 582
	i32 160, ; 583
	i32 295, ; 584
	i32 224, ; 585
	i32 10, ; 586
	i32 176, ; 587
	i32 194, ; 588
	i32 11, ; 589
	i32 208, ; 590
	i32 78, ; 591
	i32 126, ; 592
	i32 83, ; 593
	i32 184, ; 594
	i32 66, ; 595
	i32 107, ; 596
	i32 0, ; 597
	i32 65, ; 598
	i32 128, ; 599
	i32 122, ; 600
	i32 77, ; 601
	i32 272, ; 602
	i32 262, ; 603
	i32 8, ; 604
	i32 230, ; 605
	i32 2, ; 606
	i32 311, ; 607
	i32 44, ; 608
	i32 275, ; 609
	i32 156, ; 610
	i32 128, ; 611
	i32 260, ; 612
	i32 23, ; 613
	i32 133, ; 614
	i32 218, ; 615
	i32 249, ; 616
	i32 29, ; 617
	i32 217, ; 618
	i32 62, ; 619
	i32 196, ; 620
	i32 90, ; 621
	i32 175, ; 622
	i32 87, ; 623
	i32 148, ; 624
	i32 176, ; 625
	i32 297, ; 626
	i32 198, ; 627
	i32 36, ; 628
	i32 86, ; 629
	i32 238, ; 630
	i32 321, ; 631
	i32 183, ; 632
	i32 50, ; 633
	i32 6, ; 634
	i32 202, ; 635
	i32 90, ; 636
	i32 321, ; 637
	i32 21, ; 638
	i32 162, ; 639
	i32 96, ; 640
	i32 50, ; 641
	i32 113, ; 642
	i32 254, ; 643
	i32 130, ; 644
	i32 76, ; 645
	i32 27, ; 646
	i32 310, ; 647
	i32 231, ; 648
	i32 253, ; 649
	i32 7, ; 650
	i32 195, ; 651
	i32 174, ; 652
	i32 110, ; 653
	i32 254, ; 654
	i32 240 ; 655
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
