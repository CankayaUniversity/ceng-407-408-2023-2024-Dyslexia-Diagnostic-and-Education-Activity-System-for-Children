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

@assembly_image_cache = dso_local local_unnamed_addr global [337 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [668 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 256
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 290
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 38948123, ; 6: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 298
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 205
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42244203, ; 9: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 307
	i32 42639949, ; 10: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 331
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 203
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 83839681, ; 16: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 315
	i32 98325684, ; 17: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 186
	i32 101534019, ; 18: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 274
	i32 117431740, ; 19: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 20: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 274
	i32 122350210, ; 21: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 22: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 294
	i32 136584136, ; 23: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 330
	i32 140062828, ; 24: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 323
	i32 142721839, ; 25: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 26: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 27: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 28: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 230
	i32 175859233, ; 29: DyslexiaAppMAUI.Shared => 0xa7b6621 => 332
	i32 176265551, ; 30: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 31: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 276
	i32 184328833, ; 32: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 33: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 34: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 228
	i32 220171995, ; 35: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 221958352, ; 36: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 185
	i32 230216969, ; 37: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 250
	i32 230752869, ; 38: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 39: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 40: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 41: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 42: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 233
	i32 276479776, ; 43: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 277295747, ; 44: Refit.HttpClientFactory => 0x10873283 => 207
	i32 278686392, ; 45: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 252
	i32 280482487, ; 46: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 249
	i32 291076382, ; 47: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 291275502, ; 48: Microsoft.Extensions.Http.dll => 0x115c82ee => 187
	i32 298918909, ; 49: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 50: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 328
	i32 318968648, ; 51: Xamarin.AndroidX.Activity.dll => 0x13031348 => 219
	i32 321597661, ; 52: System.Numerics => 0x132b30dd => 83
	i32 321963286, ; 53: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 306
	i32 342366114, ; 54: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 251
	i32 360082299, ; 55: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 56: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 57: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 58: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 59: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 60: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 61: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 62: _Microsoft.Android.Resource.Designer => 0x17969339 => 333
	i32 403441872, ; 63: WindowsBase => 0x180c08d0 => 165
	i32 409257351, ; 64: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 326
	i32 441335492, ; 65: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 234
	i32 442565967, ; 66: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 67: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 247
	i32 451504562, ; 68: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 69: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 70: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 71: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 72: System.dll => 0x1bff388e => 164
	i32 476646585, ; 73: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 249
	i32 485463106, ; 74: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 194
	i32 486930444, ; 75: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 262
	i32 489220957, ; 76: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 304
	i32 498788369, ; 77: System.ObjectModel => 0x1dbae811 => 84
	i32 513247710, ; 78: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 193
	i32 526420162, ; 79: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 80: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 294
	i32 530272170, ; 81: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 538707440, ; 82: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 325
	i32 539058512, ; 83: Microsoft.Extensions.Logging => 0x20216150 => 188
	i32 540030774, ; 84: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 85: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 86: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 87: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 88: Jsr305Binding => 0x213954e7 => 287
	i32 569601784, ; 89: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 285
	i32 577335427, ; 90: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 586578074, ; 91: MimeKit => 0x22f6789a => 204
	i32 601371474, ; 92: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 93: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 94: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 95: Xamarin.AndroidX.CustomView => 0x2568904f => 239
	i32 627931235, ; 96: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 317
	i32 639843206, ; 97: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 245
	i32 643868501, ; 98: System.Net => 0x2660a755 => 81
	i32 662205335, ; 99: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 100: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 281
	i32 666292255, ; 101: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 226
	i32 672442732, ; 102: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 103: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 104: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 105: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 296
	i32 693804605, ; 106: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 107: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 108: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 291
	i32 700358131, ; 109: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 709152836, ; 110: System.Security.Cryptography.Pkcs.dll => 0x2a44d044 => 214
	i32 720511267, ; 111: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 295
	i32 722857257, ; 112: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 731701662, ; 113: Microsoft.Extensions.Options.ConfigurationExtensions => 0x2b9ce19e => 192
	i32 734124578, ; 114: Google.Apis.Gmail.v1 => 0x2bc1da22 => 178
	i32 735137430, ; 115: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 116: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 117: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 216
	i32 759454413, ; 118: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 119: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 120: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 121: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 323
	i32 789151979, ; 122: Microsoft.Extensions.Options => 0x2f0980eb => 191
	i32 790371945, ; 123: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 240
	i32 804715423, ; 124: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 125: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 254
	i32 823281589, ; 126: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 127: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 128: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 129: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 130: Xamarin.AndroidX.Print => 0x3246f6cd => 267
	i32 869139383, ; 131: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 308
	i32 873119928, ; 132: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 133: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 134: System.Net.Http.Json => 0x3463c971 => 63
	i32 880668424, ; 135: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 322
	i32 885382775, ; 136: Refit.Newtonsoft.Json.dll => 0x34c5de77 => 208
	i32 904024072, ; 137: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 908337989, ; 138: Refit => 0x36242345 => 206
	i32 911108515, ; 139: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 918734561, ; 140: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 319
	i32 928116545, ; 141: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 290
	i32 952186615, ; 142: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 143: Newtonsoft.Json => 0x38f24a24 => 205
	i32 956575887, ; 144: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 295
	i32 961460050, ; 145: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 312
	i32 966729478, ; 146: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 288
	i32 967690846, ; 147: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 251
	i32 975236339, ; 148: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 149: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 150: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 151: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 990727110, ; 152: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 321
	i32 992768348, ; 153: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 154: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 155: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 156: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 271
	i32 1019214401, ; 157: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 158: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 184
	i32 1031528504, ; 159: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 289
	i32 1035644815, ; 160: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 224
	i32 1036536393, ; 161: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1043950537, ; 162: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 302
	i32 1044663988, ; 163: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048992957, ; 164: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 186
	i32 1052210849, ; 165: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 258
	i32 1067306892, ; 166: GoogleGson => 0x3f9dcf8c => 179
	i32 1082857460, ; 167: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 168: Xamarin.Kotlin.StdLib => 0x409e66d8 => 292
	i32 1098259244, ; 169: System => 0x41761b2c => 164
	i32 1108272742, ; 170: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 324
	i32 1117529484, ; 171: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 318
	i32 1118262833, ; 172: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 314
	i32 1121599056, ; 173: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 257
	i32 1122549021, ; 174: Refit.HttpClientFactory.dll => 0x42e8bd1d => 207
	i32 1127624469, ; 175: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 190
	i32 1149092582, ; 176: Xamarin.AndroidX.Window => 0x447dc2e6 => 284
	i32 1168523401, ; 177: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 320
	i32 1170634674, ; 178: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 179: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 280
	i32 1178241025, ; 180: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 265
	i32 1201029973, ; 181: StarkbankEcdsa => 0x47964355 => 210
	i32 1204270330, ; 182: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 226
	i32 1208641965, ; 183: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1214827643, ; 184: CommunityToolkit.Mvvm => 0x4868cc7b => 174
	i32 1219128291, ; 185: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1243150071, ; 186: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 285
	i32 1251888248, ; 187: DyslexiaAppMAUI.Shared.dll => 0x4a9e4c78 => 332
	i32 1253011324, ; 188: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 189: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 300
	i32 1264511973, ; 190: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 275
	i32 1267360935, ; 191: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 279
	i32 1273260888, ; 192: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 231
	i32 1275534314, ; 193: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 296
	i32 1278448581, ; 194: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 223
	i32 1293217323, ; 195: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 242
	i32 1308624726, ; 196: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 309
	i32 1309188875, ; 197: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 198: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 284
	i32 1324164729, ; 199: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 200: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1336711579, ; 201: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 329
	i32 1364015309, ; 202: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 203: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 330
	i32 1376866003, ; 204: Xamarin.AndroidX.SavedState => 0x52114ed3 => 271
	i32 1379779777, ; 205: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 206: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 207: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 235
	i32 1408764838, ; 208: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 209: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 210: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 211: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 298
	i32 1433687999, ; 212: SendGrid.dll => 0x557457bf => 209
	i32 1434145427, ; 213: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 214: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 288
	i32 1439761251, ; 215: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 216: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 217: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 218: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 219: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1460893475, ; 220: System.IdentityModel.Tokens.Jwt => 0x57137723 => 212
	i32 1461004990, ; 221: es\Microsoft.Maui.Controls.resources => 0x57152abe => 304
	i32 1461234159, ; 222: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 223: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 224: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 225: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 225
	i32 1470490898, ; 226: Microsoft.Extensions.Primitives => 0x57a5e912 => 193
	i32 1479771757, ; 227: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 228: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 229: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 230: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 272
	i32 1498168481, ; 231: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 195
	i32 1505131794, ; 232: Microsoft.Extensions.Http => 0x59b67d12 => 187
	i32 1526286932, ; 233: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 328
	i32 1536373174, ; 234: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 235: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 236: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 237: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 238: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 239: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 240: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 241: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 242: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 241
	i32 1592978981, ; 243: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 244: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 289
	i32 1601112923, ; 245: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 246: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 247: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 248: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 261
	i32 1622358360, ; 249: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 250: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 283
	i32 1635184631, ; 251: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 245
	i32 1636350590, ; 252: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 238
	i32 1639515021, ; 253: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 254: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 255: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 256: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 257: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 277
	i32 1658251792, ; 258: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 286
	i32 1670060433, ; 259: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 233
	i32 1675553242, ; 260: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 261: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 262: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 263: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 264: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 265: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 266: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 293
	i32 1701541528, ; 267: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 268: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 254
	i32 1726116996, ; 269: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 270: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 271: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 229
	i32 1743415430, ; 272: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 299
	i32 1744735666, ; 273: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 274: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 275: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 276: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 277: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 278: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 279: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 276
	i32 1770582343, ; 280: Microsoft.Extensions.Logging.dll => 0x6988f147 => 188
	i32 1776026572, ; 281: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 282: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 283: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 284: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 315
	i32 1788241197, ; 285: Xamarin.AndroidX.Fragment => 0x6a96652d => 247
	i32 1793755602, ; 286: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 307
	i32 1808609942, ; 287: Xamarin.AndroidX.Loader => 0x6bcd3296 => 261
	i32 1813058853, ; 288: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 292
	i32 1813201214, ; 289: Xamarin.Google.Android.Material => 0x6c13413e => 286
	i32 1818569960, ; 290: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 266
	i32 1818787751, ; 291: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 292: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 293: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 294: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 189
	i32 1847515442, ; 295: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 216
	i32 1853025655, ; 296: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 324
	i32 1858542181, ; 297: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 298: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 299: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 306
	i32 1879696579, ; 300: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 301: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 227
	i32 1888955245, ; 302: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 303: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1893218855, ; 304: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 300
	i32 1898237753, ; 305: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 306: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 307: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1927897671, ; 308: System.CodeDom.dll => 0x72e96247 => 211
	i32 1939592360, ; 309: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1953182387, ; 310: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 311
	i32 1956758971, ; 311: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 312: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 273
	i32 1968388702, ; 313: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 180
	i32 1983156543, ; 314: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 293
	i32 1985761444, ; 315: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 218
	i32 1986222447, ; 316: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 197
	i32 2003115576, ; 317: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 303
	i32 2004041166, ; 318: Google.Apis.Gmail.v1.dll => 0x77733dce => 178
	i32 2011961780, ; 319: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 320: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 258
	i32 2031763787, ; 321: Xamarin.Android.Glide => 0x791a414b => 215
	i32 2045470958, ; 322: System.Private.Xml => 0x79eb68ee => 88
	i32 2048278909, ; 323: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 182
	i32 2055257422, ; 324: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 253
	i32 2060060697, ; 325: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 326: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 302
	i32 2070888862, ; 327: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 328: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 329: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 330: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 331: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 332: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 333: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 334: Microsoft.Maui => 0x80bd55ad => 201
	i32 2169148018, ; 335: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 310
	i32 2178612968, ; 336: System.CodeDom => 0x81dafee8 => 211
	i32 2181898931, ; 337: Microsoft.Extensions.Options.dll => 0x820d22b3 => 191
	i32 2192057212, ; 338: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 189
	i32 2193016926, ; 339: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 340: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 297
	i32 2201231467, ; 341: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 342: it\Microsoft.Maui.Controls.resources => 0x839595db => 312
	i32 2210798277, ; 343: SendGrid => 0x83c61ac5 => 209
	i32 2217644978, ; 344: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 280
	i32 2222056684, ; 345: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 346: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 262
	i32 2252106437, ; 347: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 348: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 349: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 350: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 181
	i32 2267999099, ; 351: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 217
	i32 2279755925, ; 352: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 269
	i32 2293034957, ; 353: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 354: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 355: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 356: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 316
	i32 2305521784, ; 357: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 358: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 221
	i32 2320631194, ; 359: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 360: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 361: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 362: System.Net.Primitives => 0x8c40e0db => 70
	i32 2366048013, ; 363: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 310
	i32 2368005991, ; 364: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2369706906, ; 365: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 196
	i32 2371007202, ; 366: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 180
	i32 2378619854, ; 367: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 368: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 369: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 311
	i32 2401565422, ; 370: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 371: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 244
	i32 2421380589, ; 372: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 373: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 231
	i32 2427813419, ; 374: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 308
	i32 2435356389, ; 375: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 376: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2437741907, ; 377: Refit.Newtonsoft.Json => 0x914cfd53 => 208
	i32 2454642406, ; 378: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 379: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 380: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 381: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 234
	i32 2471841756, ; 382: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 383: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 384: Microsoft.Maui.Controls => 0x93dba8a1 => 199
	i32 2483903535, ; 385: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 386: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 387: System.AppContext.dll => 0x94798bc5 => 6
	i32 2498657740, ; 388: BouncyCastle.Cryptography.dll => 0x94ee7dcc => 173
	i32 2501346920, ; 389: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2503351294, ; 390: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 314
	i32 2505896520, ; 391: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 256
	i32 2522472828, ; 392: Xamarin.Android.Glide.dll => 0x9659e17c => 215
	i32 2538310050, ; 393: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 394: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 309
	i32 2562349572, ; 395: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 396: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2576534780, ; 397: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 313
	i32 2581783588, ; 398: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 257
	i32 2581819634, ; 399: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 279
	i32 2585220780, ; 400: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 401: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 402: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 403: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 318
	i32 2605712449, ; 404: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 297
	i32 2615233544, ; 405: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 248
	i32 2616218305, ; 406: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 190
	i32 2617129537, ; 407: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 408: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 409: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 238
	i32 2624644809, ; 410: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 243
	i32 2626831493, ; 411: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 313
	i32 2627185994, ; 412: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 413: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 414: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 252
	i32 2640290731, ; 415: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 196
	i32 2663391936, ; 416: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 217
	i32 2663698177, ; 417: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 418: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 419: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 420: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 421: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 422: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 423: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 277
	i32 2715334215, ; 424: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 425: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 426: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 427: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 428: Xamarin.AndroidX.Activity => 0xa2e0939b => 219
	i32 2735172069, ; 429: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 430: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 225
	i32 2740698338, ; 431: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 299
	i32 2740948882, ; 432: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 433: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 434: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 319
	i32 2758225723, ; 435: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 200
	i32 2764765095, ; 436: Microsoft.Maui.dll => 0xa4caf7a7 => 201
	i32 2765824710, ; 437: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 438: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 291
	i32 2778768386, ; 439: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 282
	i32 2779977773, ; 440: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 270
	i32 2785988530, ; 441: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 325
	i32 2788224221, ; 442: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 248
	i32 2801831435, ; 443: Microsoft.Maui.Graphics => 0xa7008e0b => 203
	i32 2803228030, ; 444: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 445: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 235
	i32 2819470561, ; 446: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 447: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 448: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 270
	i32 2824502124, ; 449: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2838993487, ; 450: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 259
	i32 2849599387, ; 451: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 452: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 282
	i32 2855708567, ; 453: Xamarin.AndroidX.Transition => 0xaa36a797 => 278
	i32 2861098320, ; 454: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 455: Microsoft.Maui.Essentials => 0xaa8a4878 => 202
	i32 2870099610, ; 456: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 220
	i32 2875164099, ; 457: Jsr305Binding.dll => 0xab5f85c3 => 287
	i32 2875220617, ; 458: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 459: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 246
	i32 2887636118, ; 460: System.Net.dll => 0xac1dd496 => 81
	i32 2893550578, ; 461: Google.Apis.Core => 0xac7813f2 => 177
	i32 2898407901, ; 462: System.Management => 0xacc231dd => 213
	i32 2899753641, ; 463: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 464: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 465: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 466: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 467: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 468: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 283
	i32 2919462931, ; 469: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 470: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 222
	i32 2936416060, ; 471: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 472: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 473: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 474: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 475: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2971004615, ; 476: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0xb115eec7 => 192
	i32 2972252294, ; 477: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 478: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 242
	i32 2980486542, ; 479: DyslexiaApp.MAUI => 0xb1a69d8e => 0
	i32 2987532451, ; 480: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 273
	i32 2990604888, ; 481: Google.Apis => 0xb2410258 => 175
	i32 2996846495, ; 482: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 255
	i32 3016983068, ; 483: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 275
	i32 3020703001, ; 484: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 185
	i32 3023353419, ; 485: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 486: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 250
	i32 3038032645, ; 487: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 333
	i32 3053864966, ; 488: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 305
	i32 3056245963, ; 489: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 272
	i32 3057625584, ; 490: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 263
	i32 3059408633, ; 491: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 492: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 493: System.Threading.Tasks => 0xb755818f => 144
	i32 3084678329, ; 494: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 197
	i32 3090735792, ; 495: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 496: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 497: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 498: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 499: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 500: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 501: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 502: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 503: GoogleGson.dll => 0xbba64c02 => 179
	i32 3159123045, ; 504: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 505: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3171180504, ; 506: MimeKit.dll => 0xbd045fd8 => 204
	i32 3178803400, ; 507: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 264
	i32 3192346100, ; 508: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 509: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 510: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 511: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 512: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 241
	i32 3220365878, ; 513: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 514: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 515: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 516: Xamarin.AndroidX.CardView => 0xc235e84d => 229
	i32 3265493905, ; 517: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 518: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3271840132, ; 519: StarkbankEcdsa.dll => 0xc3045184 => 210
	i32 3277815716, ; 520: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 521: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 522: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 523: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 524: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 525: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 526: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 305
	i32 3312457198, ; 527: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 195
	i32 3316684772, ; 528: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 529: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 239
	i32 3317144872, ; 530: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 531: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 227
	i32 3345895724, ; 532: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 268
	i32 3346324047, ; 533: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 265
	i32 3357674450, ; 534: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 322
	i32 3358260929, ; 535: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 536: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 220
	i32 3362522851, ; 537: Xamarin.AndroidX.Core => 0xc86c06e3 => 236
	i32 3366347497, ; 538: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 539: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 269
	i32 3381016424, ; 540: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 301
	i32 3395150330, ; 541: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 542: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 543: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 240
	i32 3421170118, ; 544: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 182
	i32 3428513518, ; 545: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 183
	i32 3429136800, ; 546: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 547: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 548: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 243
	i32 3445260447, ; 549: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 550: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 198
	i32 3453592554, ; 551: Google.Apis.Core.dll => 0xcdd9a3ea => 177
	i32 3458724246, ; 552: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 320
	i32 3471940407, ; 553: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 554: Mono.Android => 0xcf3163e6 => 171
	i32 3484440000, ; 555: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 321
	i32 3485117614, ; 556: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 557: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 558: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 232
	i32 3509114376, ; 559: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 560: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 561: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 562: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 563: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 564: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 565: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 329
	i32 3592228221, ; 566: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 331
	i32 3597029428, ; 567: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 218
	i32 3598340787, ; 568: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3605570793, ; 569: BouncyCastle.Cryptography => 0xd6e8a4e9 => 173
	i32 3608519521, ; 570: System.Linq.dll => 0xd715a361 => 61
	i32 3612435020, ; 571: System.Management.dll => 0xd751624c => 213
	i32 3624195450, ; 572: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 573: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 267
	i32 3633644679, ; 574: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 222
	i32 3638274909, ; 575: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 576: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 253
	i32 3643446276, ; 577: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 326
	i32 3643854240, ; 578: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 264
	i32 3645089577, ; 579: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 580: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 181
	i32 3660523487, ; 581: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 582: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 583: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 228
	i32 3684561358, ; 584: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 232
	i32 3700591436, ; 585: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 194
	i32 3700866549, ; 586: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 587: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 237
	i32 3716563718, ; 588: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 589: Xamarin.AndroidX.Annotation => 0xdda814c6 => 221
	i32 3724971120, ; 590: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 263
	i32 3732100267, ; 591: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 592: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 593: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 594: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3751619990, ; 595: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 301
	i32 3786282454, ; 596: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 230
	i32 3792276235, ; 597: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3793997468, ; 598: Google.Apis.Auth.dll => 0xe223ce9c => 176
	i32 3800979733, ; 599: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 198
	i32 3802395368, ; 600: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3807198597, ; 601: System.Security.Cryptography.Pkcs => 0xe2ed3d85 => 214
	i32 3819260425, ; 602: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 603: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 604: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 605: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 184
	i32 3844307129, ; 606: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 607: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3863245636, ; 608: DyslexiaApp.MAUI.dll => 0xe6447344 => 0
	i32 3870376305, ; 609: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 610: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 611: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 612: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 613: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 278
	i32 3888767677, ; 614: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 268
	i32 3896106733, ; 615: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 616: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 236
	i32 3901907137, ; 617: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920221145, ; 618: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 317
	i32 3920810846, ; 619: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 620: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 281
	i32 3928044579, ; 621: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 622: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 623: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 266
	i32 3945713374, ; 624: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 625: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 626: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 224
	i32 3959773229, ; 627: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 255
	i32 4003436829, ; 628: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 629: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 223
	i32 4025784931, ; 630: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 631: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 200
	i32 4054681211, ; 632: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4059682726, ; 633: Google.Apis.dll => 0xf1f9d7a6 => 175
	i32 4068434129, ; 634: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 635: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4082882467, ; 636: Google.Apis.Auth => 0xf35bd7a3 => 176
	i32 4091086043, ; 637: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 303
	i32 4094352644, ; 638: Microsoft.Maui.Essentials.dll => 0xf40add04 => 202
	i32 4099507663, ; 639: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 640: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 641: Xamarin.AndroidX.Emoji2 => 0xf479582c => 244
	i32 4103439459, ; 642: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 327
	i32 4126470640, ; 643: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 183
	i32 4127667938, ; 644: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 645: System.AppContext => 0xf6318da0 => 6
	i32 4144683026, ; 646: Refit.dll => 0xf70ad812 => 206
	i32 4147896353, ; 647: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 648: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 327
	i32 4151237749, ; 649: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 650: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 651: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 652: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 653: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 654: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 260
	i32 4185676441, ; 655: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 656: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 657: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4249188766, ; 658: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 316
	i32 4256097574, ; 659: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 237
	i32 4258378803, ; 660: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 259
	i32 4260525087, ; 661: System.Buffers => 0xfdf2741f => 7
	i32 4263231520, ; 662: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 212
	i32 4271975918, ; 663: Microsoft.Maui.Controls.dll => 0xfea12dee => 199
	i32 4274623895, ; 664: CommunityToolkit.Mvvm.dll => 0xfec99597 => 174
	i32 4274976490, ; 665: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 666: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 260
	i32 4294763496 ; 667: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 246
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [668 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 256, ; 3
	i32 290, ; 4
	i32 48, ; 5
	i32 298, ; 6
	i32 205, ; 7
	i32 80, ; 8
	i32 307, ; 9
	i32 145, ; 10
	i32 30, ; 11
	i32 331, ; 12
	i32 124, ; 13
	i32 203, ; 14
	i32 102, ; 15
	i32 315, ; 16
	i32 186, ; 17
	i32 274, ; 18
	i32 107, ; 19
	i32 274, ; 20
	i32 139, ; 21
	i32 294, ; 22
	i32 330, ; 23
	i32 323, ; 24
	i32 77, ; 25
	i32 124, ; 26
	i32 13, ; 27
	i32 230, ; 28
	i32 332, ; 29
	i32 132, ; 30
	i32 276, ; 31
	i32 151, ; 32
	i32 18, ; 33
	i32 228, ; 34
	i32 26, ; 35
	i32 185, ; 36
	i32 250, ; 37
	i32 1, ; 38
	i32 59, ; 39
	i32 42, ; 40
	i32 91, ; 41
	i32 233, ; 42
	i32 147, ; 43
	i32 207, ; 44
	i32 252, ; 45
	i32 249, ; 46
	i32 54, ; 47
	i32 187, ; 48
	i32 69, ; 49
	i32 328, ; 50
	i32 219, ; 51
	i32 83, ; 52
	i32 306, ; 53
	i32 251, ; 54
	i32 131, ; 55
	i32 55, ; 56
	i32 149, ; 57
	i32 74, ; 58
	i32 145, ; 59
	i32 62, ; 60
	i32 146, ; 61
	i32 333, ; 62
	i32 165, ; 63
	i32 326, ; 64
	i32 234, ; 65
	i32 12, ; 66
	i32 247, ; 67
	i32 125, ; 68
	i32 152, ; 69
	i32 113, ; 70
	i32 166, ; 71
	i32 164, ; 72
	i32 249, ; 73
	i32 194, ; 74
	i32 262, ; 75
	i32 304, ; 76
	i32 84, ; 77
	i32 193, ; 78
	i32 150, ; 79
	i32 294, ; 80
	i32 60, ; 81
	i32 325, ; 82
	i32 188, ; 83
	i32 51, ; 84
	i32 103, ; 85
	i32 114, ; 86
	i32 40, ; 87
	i32 287, ; 88
	i32 285, ; 89
	i32 120, ; 90
	i32 204, ; 91
	i32 52, ; 92
	i32 44, ; 93
	i32 119, ; 94
	i32 239, ; 95
	i32 317, ; 96
	i32 245, ; 97
	i32 81, ; 98
	i32 136, ; 99
	i32 281, ; 100
	i32 226, ; 101
	i32 8, ; 102
	i32 73, ; 103
	i32 155, ; 104
	i32 296, ; 105
	i32 154, ; 106
	i32 92, ; 107
	i32 291, ; 108
	i32 45, ; 109
	i32 214, ; 110
	i32 295, ; 111
	i32 109, ; 112
	i32 192, ; 113
	i32 178, ; 114
	i32 129, ; 115
	i32 25, ; 116
	i32 216, ; 117
	i32 72, ; 118
	i32 55, ; 119
	i32 46, ; 120
	i32 323, ; 121
	i32 191, ; 122
	i32 240, ; 123
	i32 22, ; 124
	i32 254, ; 125
	i32 86, ; 126
	i32 43, ; 127
	i32 160, ; 128
	i32 71, ; 129
	i32 267, ; 130
	i32 308, ; 131
	i32 3, ; 132
	i32 42, ; 133
	i32 63, ; 134
	i32 322, ; 135
	i32 208, ; 136
	i32 16, ; 137
	i32 206, ; 138
	i32 53, ; 139
	i32 319, ; 140
	i32 290, ; 141
	i32 105, ; 142
	i32 205, ; 143
	i32 295, ; 144
	i32 312, ; 145
	i32 288, ; 146
	i32 251, ; 147
	i32 34, ; 148
	i32 158, ; 149
	i32 85, ; 150
	i32 32, ; 151
	i32 321, ; 152
	i32 12, ; 153
	i32 51, ; 154
	i32 56, ; 155
	i32 271, ; 156
	i32 36, ; 157
	i32 184, ; 158
	i32 289, ; 159
	i32 224, ; 160
	i32 35, ; 161
	i32 302, ; 162
	i32 58, ; 163
	i32 186, ; 164
	i32 258, ; 165
	i32 179, ; 166
	i32 17, ; 167
	i32 292, ; 168
	i32 164, ; 169
	i32 324, ; 170
	i32 318, ; 171
	i32 314, ; 172
	i32 257, ; 173
	i32 207, ; 174
	i32 190, ; 175
	i32 284, ; 176
	i32 320, ; 177
	i32 153, ; 178
	i32 280, ; 179
	i32 265, ; 180
	i32 210, ; 181
	i32 226, ; 182
	i32 29, ; 183
	i32 174, ; 184
	i32 52, ; 185
	i32 285, ; 186
	i32 332, ; 187
	i32 5, ; 188
	i32 300, ; 189
	i32 275, ; 190
	i32 279, ; 191
	i32 231, ; 192
	i32 296, ; 193
	i32 223, ; 194
	i32 242, ; 195
	i32 309, ; 196
	i32 85, ; 197
	i32 284, ; 198
	i32 61, ; 199
	i32 112, ; 200
	i32 329, ; 201
	i32 57, ; 202
	i32 330, ; 203
	i32 271, ; 204
	i32 99, ; 205
	i32 19, ; 206
	i32 235, ; 207
	i32 111, ; 208
	i32 101, ; 209
	i32 102, ; 210
	i32 298, ; 211
	i32 209, ; 212
	i32 104, ; 213
	i32 288, ; 214
	i32 71, ; 215
	i32 38, ; 216
	i32 32, ; 217
	i32 103, ; 218
	i32 73, ; 219
	i32 212, ; 220
	i32 304, ; 221
	i32 9, ; 222
	i32 123, ; 223
	i32 46, ; 224
	i32 225, ; 225
	i32 193, ; 226
	i32 9, ; 227
	i32 43, ; 228
	i32 4, ; 229
	i32 272, ; 230
	i32 195, ; 231
	i32 187, ; 232
	i32 328, ; 233
	i32 31, ; 234
	i32 138, ; 235
	i32 92, ; 236
	i32 93, ; 237
	i32 49, ; 238
	i32 141, ; 239
	i32 112, ; 240
	i32 140, ; 241
	i32 241, ; 242
	i32 115, ; 243
	i32 289, ; 244
	i32 157, ; 245
	i32 76, ; 246
	i32 79, ; 247
	i32 261, ; 248
	i32 37, ; 249
	i32 283, ; 250
	i32 245, ; 251
	i32 238, ; 252
	i32 64, ; 253
	i32 138, ; 254
	i32 15, ; 255
	i32 116, ; 256
	i32 277, ; 257
	i32 286, ; 258
	i32 233, ; 259
	i32 48, ; 260
	i32 70, ; 261
	i32 80, ; 262
	i32 126, ; 263
	i32 94, ; 264
	i32 121, ; 265
	i32 293, ; 266
	i32 26, ; 267
	i32 254, ; 268
	i32 97, ; 269
	i32 28, ; 270
	i32 229, ; 271
	i32 299, ; 272
	i32 149, ; 273
	i32 169, ; 274
	i32 4, ; 275
	i32 98, ; 276
	i32 33, ; 277
	i32 93, ; 278
	i32 276, ; 279
	i32 188, ; 280
	i32 21, ; 281
	i32 41, ; 282
	i32 170, ; 283
	i32 315, ; 284
	i32 247, ; 285
	i32 307, ; 286
	i32 261, ; 287
	i32 292, ; 288
	i32 286, ; 289
	i32 266, ; 290
	i32 2, ; 291
	i32 134, ; 292
	i32 111, ; 293
	i32 189, ; 294
	i32 216, ; 295
	i32 324, ; 296
	i32 58, ; 297
	i32 95, ; 298
	i32 306, ; 299
	i32 39, ; 300
	i32 227, ; 301
	i32 25, ; 302
	i32 94, ; 303
	i32 300, ; 304
	i32 89, ; 305
	i32 99, ; 306
	i32 10, ; 307
	i32 211, ; 308
	i32 87, ; 309
	i32 311, ; 310
	i32 100, ; 311
	i32 273, ; 312
	i32 180, ; 313
	i32 293, ; 314
	i32 218, ; 315
	i32 197, ; 316
	i32 303, ; 317
	i32 178, ; 318
	i32 7, ; 319
	i32 258, ; 320
	i32 215, ; 321
	i32 88, ; 322
	i32 182, ; 323
	i32 253, ; 324
	i32 154, ; 325
	i32 302, ; 326
	i32 33, ; 327
	i32 116, ; 328
	i32 82, ; 329
	i32 20, ; 330
	i32 11, ; 331
	i32 162, ; 332
	i32 3, ; 333
	i32 201, ; 334
	i32 310, ; 335
	i32 211, ; 336
	i32 191, ; 337
	i32 189, ; 338
	i32 84, ; 339
	i32 297, ; 340
	i32 64, ; 341
	i32 312, ; 342
	i32 209, ; 343
	i32 280, ; 344
	i32 143, ; 345
	i32 262, ; 346
	i32 157, ; 347
	i32 41, ; 348
	i32 117, ; 349
	i32 181, ; 350
	i32 217, ; 351
	i32 269, ; 352
	i32 131, ; 353
	i32 75, ; 354
	i32 66, ; 355
	i32 316, ; 356
	i32 172, ; 357
	i32 221, ; 358
	i32 143, ; 359
	i32 106, ; 360
	i32 151, ; 361
	i32 70, ; 362
	i32 310, ; 363
	i32 156, ; 364
	i32 196, ; 365
	i32 180, ; 366
	i32 121, ; 367
	i32 127, ; 368
	i32 311, ; 369
	i32 152, ; 370
	i32 244, ; 371
	i32 141, ; 372
	i32 231, ; 373
	i32 308, ; 374
	i32 20, ; 375
	i32 14, ; 376
	i32 208, ; 377
	i32 135, ; 378
	i32 75, ; 379
	i32 59, ; 380
	i32 234, ; 381
	i32 167, ; 382
	i32 168, ; 383
	i32 199, ; 384
	i32 15, ; 385
	i32 74, ; 386
	i32 6, ; 387
	i32 173, ; 388
	i32 23, ; 389
	i32 314, ; 390
	i32 256, ; 391
	i32 215, ; 392
	i32 91, ; 393
	i32 309, ; 394
	i32 1, ; 395
	i32 136, ; 396
	i32 313, ; 397
	i32 257, ; 398
	i32 279, ; 399
	i32 134, ; 400
	i32 69, ; 401
	i32 146, ; 402
	i32 318, ; 403
	i32 297, ; 404
	i32 248, ; 405
	i32 190, ; 406
	i32 88, ; 407
	i32 96, ; 408
	i32 238, ; 409
	i32 243, ; 410
	i32 313, ; 411
	i32 31, ; 412
	i32 45, ; 413
	i32 252, ; 414
	i32 196, ; 415
	i32 217, ; 416
	i32 109, ; 417
	i32 158, ; 418
	i32 35, ; 419
	i32 22, ; 420
	i32 114, ; 421
	i32 57, ; 422
	i32 277, ; 423
	i32 144, ; 424
	i32 118, ; 425
	i32 120, ; 426
	i32 110, ; 427
	i32 219, ; 428
	i32 139, ; 429
	i32 225, ; 430
	i32 299, ; 431
	i32 54, ; 432
	i32 105, ; 433
	i32 319, ; 434
	i32 200, ; 435
	i32 201, ; 436
	i32 133, ; 437
	i32 291, ; 438
	i32 282, ; 439
	i32 270, ; 440
	i32 325, ; 441
	i32 248, ; 442
	i32 203, ; 443
	i32 159, ; 444
	i32 235, ; 445
	i32 163, ; 446
	i32 132, ; 447
	i32 270, ; 448
	i32 161, ; 449
	i32 259, ; 450
	i32 140, ; 451
	i32 282, ; 452
	i32 278, ; 453
	i32 169, ; 454
	i32 202, ; 455
	i32 220, ; 456
	i32 287, ; 457
	i32 40, ; 458
	i32 246, ; 459
	i32 81, ; 460
	i32 177, ; 461
	i32 213, ; 462
	i32 56, ; 463
	i32 37, ; 464
	i32 97, ; 465
	i32 166, ; 466
	i32 172, ; 467
	i32 283, ; 468
	i32 82, ; 469
	i32 222, ; 470
	i32 98, ; 471
	i32 30, ; 472
	i32 159, ; 473
	i32 18, ; 474
	i32 127, ; 475
	i32 192, ; 476
	i32 119, ; 477
	i32 242, ; 478
	i32 0, ; 479
	i32 273, ; 480
	i32 175, ; 481
	i32 255, ; 482
	i32 275, ; 483
	i32 185, ; 484
	i32 165, ; 485
	i32 250, ; 486
	i32 333, ; 487
	i32 305, ; 488
	i32 272, ; 489
	i32 263, ; 490
	i32 170, ; 491
	i32 16, ; 492
	i32 144, ; 493
	i32 197, ; 494
	i32 125, ; 495
	i32 118, ; 496
	i32 38, ; 497
	i32 115, ; 498
	i32 47, ; 499
	i32 142, ; 500
	i32 117, ; 501
	i32 34, ; 502
	i32 179, ; 503
	i32 95, ; 504
	i32 53, ; 505
	i32 204, ; 506
	i32 264, ; 507
	i32 129, ; 508
	i32 153, ; 509
	i32 24, ; 510
	i32 161, ; 511
	i32 241, ; 512
	i32 148, ; 513
	i32 104, ; 514
	i32 89, ; 515
	i32 229, ; 516
	i32 60, ; 517
	i32 142, ; 518
	i32 210, ; 519
	i32 100, ; 520
	i32 5, ; 521
	i32 13, ; 522
	i32 122, ; 523
	i32 135, ; 524
	i32 28, ; 525
	i32 305, ; 526
	i32 195, ; 527
	i32 72, ; 528
	i32 239, ; 529
	i32 24, ; 530
	i32 227, ; 531
	i32 268, ; 532
	i32 265, ; 533
	i32 322, ; 534
	i32 137, ; 535
	i32 220, ; 536
	i32 236, ; 537
	i32 168, ; 538
	i32 269, ; 539
	i32 301, ; 540
	i32 101, ; 541
	i32 123, ; 542
	i32 240, ; 543
	i32 182, ; 544
	i32 183, ; 545
	i32 163, ; 546
	i32 167, ; 547
	i32 243, ; 548
	i32 39, ; 549
	i32 198, ; 550
	i32 177, ; 551
	i32 320, ; 552
	i32 17, ; 553
	i32 171, ; 554
	i32 321, ; 555
	i32 137, ; 556
	i32 150, ; 557
	i32 232, ; 558
	i32 155, ; 559
	i32 130, ; 560
	i32 19, ; 561
	i32 65, ; 562
	i32 147, ; 563
	i32 47, ; 564
	i32 329, ; 565
	i32 331, ; 566
	i32 218, ; 567
	i32 79, ; 568
	i32 173, ; 569
	i32 61, ; 570
	i32 213, ; 571
	i32 106, ; 572
	i32 267, ; 573
	i32 222, ; 574
	i32 49, ; 575
	i32 253, ; 576
	i32 326, ; 577
	i32 264, ; 578
	i32 14, ; 579
	i32 181, ; 580
	i32 68, ; 581
	i32 171, ; 582
	i32 228, ; 583
	i32 232, ; 584
	i32 194, ; 585
	i32 78, ; 586
	i32 237, ; 587
	i32 108, ; 588
	i32 221, ; 589
	i32 263, ; 590
	i32 67, ; 591
	i32 63, ; 592
	i32 27, ; 593
	i32 160, ; 594
	i32 301, ; 595
	i32 230, ; 596
	i32 10, ; 597
	i32 176, ; 598
	i32 198, ; 599
	i32 11, ; 600
	i32 214, ; 601
	i32 78, ; 602
	i32 126, ; 603
	i32 83, ; 604
	i32 184, ; 605
	i32 66, ; 606
	i32 107, ; 607
	i32 0, ; 608
	i32 65, ; 609
	i32 128, ; 610
	i32 122, ; 611
	i32 77, ; 612
	i32 278, ; 613
	i32 268, ; 614
	i32 8, ; 615
	i32 236, ; 616
	i32 2, ; 617
	i32 317, ; 618
	i32 44, ; 619
	i32 281, ; 620
	i32 156, ; 621
	i32 128, ; 622
	i32 266, ; 623
	i32 23, ; 624
	i32 133, ; 625
	i32 224, ; 626
	i32 255, ; 627
	i32 29, ; 628
	i32 223, ; 629
	i32 62, ; 630
	i32 200, ; 631
	i32 90, ; 632
	i32 175, ; 633
	i32 87, ; 634
	i32 148, ; 635
	i32 176, ; 636
	i32 303, ; 637
	i32 202, ; 638
	i32 36, ; 639
	i32 86, ; 640
	i32 244, ; 641
	i32 327, ; 642
	i32 183, ; 643
	i32 50, ; 644
	i32 6, ; 645
	i32 206, ; 646
	i32 90, ; 647
	i32 327, ; 648
	i32 21, ; 649
	i32 162, ; 650
	i32 96, ; 651
	i32 50, ; 652
	i32 113, ; 653
	i32 260, ; 654
	i32 130, ; 655
	i32 76, ; 656
	i32 27, ; 657
	i32 316, ; 658
	i32 237, ; 659
	i32 259, ; 660
	i32 7, ; 661
	i32 212, ; 662
	i32 199, ; 663
	i32 174, ; 664
	i32 110, ; 665
	i32 260, ; 666
	i32 246 ; 667
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
