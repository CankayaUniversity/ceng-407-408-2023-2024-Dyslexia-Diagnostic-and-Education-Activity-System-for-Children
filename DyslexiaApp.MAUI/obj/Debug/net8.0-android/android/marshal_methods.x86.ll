; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [336 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [666 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 255
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 289
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 38948123, ; 6: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 297
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 205
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42244203, ; 9: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 306
	i32 42639949, ; 10: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 330
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 203
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 83839681, ; 16: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 314
	i32 98325684, ; 17: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 186
	i32 101534019, ; 18: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 273
	i32 117431740, ; 19: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 20: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 273
	i32 122350210, ; 21: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 22: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 293
	i32 136584136, ; 23: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 329
	i32 140062828, ; 24: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 322
	i32 142721839, ; 25: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 26: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 27: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 28: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 229
	i32 175859233, ; 29: DyslexiaAppMAUI.Shared => 0xa7b6621 => 331
	i32 176265551, ; 30: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 31: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 275
	i32 184328833, ; 32: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 33: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 34: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 227
	i32 220171995, ; 35: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 221958352, ; 36: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 185
	i32 230216969, ; 37: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 249
	i32 230752869, ; 38: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 39: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 40: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 41: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 42: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 232
	i32 276479776, ; 43: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 277295747, ; 44: Refit.HttpClientFactory => 0x10873283 => 207
	i32 278686392, ; 45: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 251
	i32 280482487, ; 46: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 248
	i32 291076382, ; 47: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 291275502, ; 48: Microsoft.Extensions.Http.dll => 0x115c82ee => 187
	i32 298918909, ; 49: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 50: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 327
	i32 318968648, ; 51: Xamarin.AndroidX.Activity.dll => 0x13031348 => 218
	i32 321597661, ; 52: System.Numerics => 0x132b30dd => 83
	i32 321963286, ; 53: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 305
	i32 342366114, ; 54: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 250
	i32 360082299, ; 55: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 56: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 57: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 58: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 59: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 60: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 61: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 62: _Microsoft.Android.Resource.Designer => 0x17969339 => 332
	i32 403441872, ; 63: WindowsBase => 0x180c08d0 => 165
	i32 409257351, ; 64: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 325
	i32 441335492, ; 65: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 233
	i32 442565967, ; 66: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 67: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 246
	i32 451504562, ; 68: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 69: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 70: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 71: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 72: System.dll => 0x1bff388e => 164
	i32 476646585, ; 73: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 248
	i32 485463106, ; 74: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 194
	i32 486930444, ; 75: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 261
	i32 489220957, ; 76: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 303
	i32 498788369, ; 77: System.ObjectModel => 0x1dbae811 => 84
	i32 513247710, ; 78: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 193
	i32 526420162, ; 79: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 80: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 293
	i32 530272170, ; 81: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 538707440, ; 82: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 324
	i32 539058512, ; 83: Microsoft.Extensions.Logging => 0x20216150 => 188
	i32 540030774, ; 84: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 85: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 86: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 87: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 88: Jsr305Binding => 0x213954e7 => 286
	i32 569601784, ; 89: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 284
	i32 577335427, ; 90: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 586578074, ; 91: MimeKit => 0x22f6789a => 204
	i32 601371474, ; 92: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 93: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 94: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 95: Xamarin.AndroidX.CustomView => 0x2568904f => 238
	i32 627931235, ; 96: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 316
	i32 639843206, ; 97: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 244
	i32 643868501, ; 98: System.Net => 0x2660a755 => 81
	i32 662205335, ; 99: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 100: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 280
	i32 666292255, ; 101: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 225
	i32 672442732, ; 102: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 103: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 104: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 105: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 295
	i32 693804605, ; 106: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 107: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 108: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 290
	i32 700358131, ; 109: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 709152836, ; 110: System.Security.Cryptography.Pkcs.dll => 0x2a44d044 => 213
	i32 720511267, ; 111: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 294
	i32 722857257, ; 112: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 731701662, ; 113: Microsoft.Extensions.Options.ConfigurationExtensions => 0x2b9ce19e => 192
	i32 734124578, ; 114: Google.Apis.Gmail.v1 => 0x2bc1da22 => 178
	i32 735137430, ; 115: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 116: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 117: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 215
	i32 759454413, ; 118: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 119: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 120: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 121: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 322
	i32 789151979, ; 122: Microsoft.Extensions.Options => 0x2f0980eb => 191
	i32 790371945, ; 123: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 239
	i32 804715423, ; 124: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 125: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 253
	i32 823281589, ; 126: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 127: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 128: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 129: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 130: Xamarin.AndroidX.Print => 0x3246f6cd => 266
	i32 869139383, ; 131: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 307
	i32 873119928, ; 132: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 133: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 134: System.Net.Http.Json => 0x3463c971 => 63
	i32 880668424, ; 135: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 321
	i32 904024072, ; 136: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 908337989, ; 137: Refit => 0x36242345 => 206
	i32 911108515, ; 138: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 918734561, ; 139: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 318
	i32 928116545, ; 140: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 289
	i32 952186615, ; 141: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 142: Newtonsoft.Json => 0x38f24a24 => 205
	i32 956575887, ; 143: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 294
	i32 961460050, ; 144: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 311
	i32 966729478, ; 145: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 287
	i32 967690846, ; 146: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 250
	i32 975236339, ; 147: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 148: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 149: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 150: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 990727110, ; 151: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 320
	i32 992768348, ; 152: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 153: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 154: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 155: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 270
	i32 1019214401, ; 156: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 157: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 184
	i32 1031528504, ; 158: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 288
	i32 1035644815, ; 159: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 223
	i32 1036536393, ; 160: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1043950537, ; 161: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 301
	i32 1044663988, ; 162: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048992957, ; 163: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 186
	i32 1052210849, ; 164: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 257
	i32 1067306892, ; 165: GoogleGson => 0x3f9dcf8c => 179
	i32 1082857460, ; 166: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 167: Xamarin.Kotlin.StdLib => 0x409e66d8 => 291
	i32 1098259244, ; 168: System => 0x41761b2c => 164
	i32 1108272742, ; 169: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 323
	i32 1117529484, ; 170: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 317
	i32 1118262833, ; 171: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 313
	i32 1121599056, ; 172: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 256
	i32 1122549021, ; 173: Refit.HttpClientFactory.dll => 0x42e8bd1d => 207
	i32 1127624469, ; 174: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 190
	i32 1149092582, ; 175: Xamarin.AndroidX.Window => 0x447dc2e6 => 283
	i32 1168523401, ; 176: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 319
	i32 1170634674, ; 177: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 178: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 279
	i32 1178241025, ; 179: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 264
	i32 1201029973, ; 180: StarkbankEcdsa => 0x47964355 => 209
	i32 1204270330, ; 181: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 225
	i32 1208641965, ; 182: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1214827643, ; 183: CommunityToolkit.Mvvm => 0x4868cc7b => 174
	i32 1219128291, ; 184: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1243150071, ; 185: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 284
	i32 1251888248, ; 186: DyslexiaAppMAUI.Shared.dll => 0x4a9e4c78 => 331
	i32 1253011324, ; 187: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 188: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 299
	i32 1264511973, ; 189: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 274
	i32 1267360935, ; 190: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 278
	i32 1273260888, ; 191: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 230
	i32 1275534314, ; 192: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 295
	i32 1278448581, ; 193: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 222
	i32 1293217323, ; 194: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 241
	i32 1308624726, ; 195: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 308
	i32 1309188875, ; 196: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 197: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 283
	i32 1324164729, ; 198: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 199: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1336711579, ; 200: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 328
	i32 1364015309, ; 201: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 202: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 329
	i32 1376866003, ; 203: Xamarin.AndroidX.SavedState => 0x52114ed3 => 270
	i32 1379779777, ; 204: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 205: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 206: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 234
	i32 1408764838, ; 207: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 208: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 209: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 210: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 297
	i32 1433687999, ; 211: SendGrid.dll => 0x557457bf => 208
	i32 1434145427, ; 212: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 213: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 287
	i32 1439761251, ; 214: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 215: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 216: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 217: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 218: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1460893475, ; 219: System.IdentityModel.Tokens.Jwt => 0x57137723 => 211
	i32 1461004990, ; 220: es\Microsoft.Maui.Controls.resources => 0x57152abe => 303
	i32 1461234159, ; 221: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 222: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 223: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 224: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 224
	i32 1470490898, ; 225: Microsoft.Extensions.Primitives => 0x57a5e912 => 193
	i32 1479771757, ; 226: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 227: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 228: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 229: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 271
	i32 1498168481, ; 230: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 195
	i32 1505131794, ; 231: Microsoft.Extensions.Http => 0x59b67d12 => 187
	i32 1526286932, ; 232: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 327
	i32 1536373174, ; 233: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 234: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 235: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 236: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 237: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 238: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 239: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 240: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 241: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 240
	i32 1592978981, ; 242: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 243: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 288
	i32 1601112923, ; 244: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 245: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 246: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 247: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 260
	i32 1622358360, ; 248: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 249: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 282
	i32 1635184631, ; 250: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 244
	i32 1636350590, ; 251: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 237
	i32 1639515021, ; 252: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 253: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 254: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 255: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 256: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 276
	i32 1658251792, ; 257: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 285
	i32 1670060433, ; 258: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 232
	i32 1675553242, ; 259: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 260: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 261: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 262: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 263: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 264: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 265: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 292
	i32 1701541528, ; 266: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 267: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 253
	i32 1726116996, ; 268: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 269: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 270: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 228
	i32 1743415430, ; 271: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 298
	i32 1744735666, ; 272: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 273: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 274: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 275: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 276: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 277: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 278: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 275
	i32 1770582343, ; 279: Microsoft.Extensions.Logging.dll => 0x6988f147 => 188
	i32 1776026572, ; 280: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 281: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 282: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 283: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 314
	i32 1788241197, ; 284: Xamarin.AndroidX.Fragment => 0x6a96652d => 246
	i32 1793755602, ; 285: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 306
	i32 1808609942, ; 286: Xamarin.AndroidX.Loader => 0x6bcd3296 => 260
	i32 1813058853, ; 287: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 291
	i32 1813201214, ; 288: Xamarin.Google.Android.Material => 0x6c13413e => 285
	i32 1818569960, ; 289: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 265
	i32 1818787751, ; 290: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 291: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 292: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 293: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 189
	i32 1847515442, ; 294: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 215
	i32 1853025655, ; 295: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 323
	i32 1858542181, ; 296: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 297: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 298: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 305
	i32 1879696579, ; 299: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 300: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 226
	i32 1888955245, ; 301: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 302: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1893218855, ; 303: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 299
	i32 1898237753, ; 304: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 305: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 306: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1927897671, ; 307: System.CodeDom.dll => 0x72e96247 => 210
	i32 1939592360, ; 308: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1953182387, ; 309: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 310
	i32 1956758971, ; 310: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 311: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 272
	i32 1968388702, ; 312: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 180
	i32 1983156543, ; 313: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 292
	i32 1985761444, ; 314: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 217
	i32 1986222447, ; 315: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 197
	i32 2003115576, ; 316: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 302
	i32 2004041166, ; 317: Google.Apis.Gmail.v1.dll => 0x77733dce => 178
	i32 2011961780, ; 318: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 319: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 257
	i32 2031763787, ; 320: Xamarin.Android.Glide => 0x791a414b => 214
	i32 2045470958, ; 321: System.Private.Xml => 0x79eb68ee => 88
	i32 2048278909, ; 322: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 182
	i32 2055257422, ; 323: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 252
	i32 2060060697, ; 324: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 325: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 301
	i32 2070888862, ; 326: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 327: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 328: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 329: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 330: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 331: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 332: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 333: Microsoft.Maui => 0x80bd55ad => 201
	i32 2169148018, ; 334: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 309
	i32 2178612968, ; 335: System.CodeDom => 0x81dafee8 => 210
	i32 2181898931, ; 336: Microsoft.Extensions.Options.dll => 0x820d22b3 => 191
	i32 2192057212, ; 337: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 189
	i32 2193016926, ; 338: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 339: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 296
	i32 2201231467, ; 340: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 341: it\Microsoft.Maui.Controls.resources => 0x839595db => 311
	i32 2210798277, ; 342: SendGrid => 0x83c61ac5 => 208
	i32 2217644978, ; 343: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 279
	i32 2222056684, ; 344: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 345: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 261
	i32 2252106437, ; 346: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 347: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 348: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 349: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 181
	i32 2267999099, ; 350: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 216
	i32 2279755925, ; 351: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 268
	i32 2293034957, ; 352: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 353: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 354: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 355: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 315
	i32 2305521784, ; 356: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 357: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 220
	i32 2320631194, ; 358: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 359: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 360: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 361: System.Net.Primitives => 0x8c40e0db => 70
	i32 2366048013, ; 362: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 309
	i32 2368005991, ; 363: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2369706906, ; 364: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 196
	i32 2371007202, ; 365: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 180
	i32 2378619854, ; 366: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 367: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 368: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 310
	i32 2401565422, ; 369: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 370: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 243
	i32 2421380589, ; 371: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 372: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 230
	i32 2427813419, ; 373: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 307
	i32 2435356389, ; 374: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 375: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 376: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 377: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 378: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 379: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 233
	i32 2471841756, ; 380: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 381: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 382: Microsoft.Maui.Controls => 0x93dba8a1 => 199
	i32 2483903535, ; 383: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 384: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 385: System.AppContext.dll => 0x94798bc5 => 6
	i32 2498657740, ; 386: BouncyCastle.Cryptography.dll => 0x94ee7dcc => 173
	i32 2501346920, ; 387: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2503351294, ; 388: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 313
	i32 2505896520, ; 389: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 255
	i32 2522472828, ; 390: Xamarin.Android.Glide.dll => 0x9659e17c => 214
	i32 2538310050, ; 391: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 392: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 308
	i32 2562349572, ; 393: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 394: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2576534780, ; 395: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 312
	i32 2581783588, ; 396: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 256
	i32 2581819634, ; 397: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 278
	i32 2585220780, ; 398: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 399: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 400: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 401: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 317
	i32 2605712449, ; 402: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 296
	i32 2615233544, ; 403: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 247
	i32 2616218305, ; 404: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 190
	i32 2617129537, ; 405: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 406: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 407: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 237
	i32 2624644809, ; 408: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 242
	i32 2626831493, ; 409: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 312
	i32 2627185994, ; 410: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 411: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 412: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 251
	i32 2640290731, ; 413: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 196
	i32 2663391936, ; 414: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 216
	i32 2663698177, ; 415: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 416: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 417: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 418: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 419: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 420: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 421: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 276
	i32 2715334215, ; 422: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 423: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 424: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 425: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 426: Xamarin.AndroidX.Activity => 0xa2e0939b => 218
	i32 2735172069, ; 427: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 428: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 224
	i32 2740698338, ; 429: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 298
	i32 2740948882, ; 430: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 431: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 432: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 318
	i32 2758225723, ; 433: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 200
	i32 2764765095, ; 434: Microsoft.Maui.dll => 0xa4caf7a7 => 201
	i32 2765824710, ; 435: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 436: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 290
	i32 2778768386, ; 437: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 281
	i32 2779977773, ; 438: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 269
	i32 2785988530, ; 439: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 324
	i32 2788224221, ; 440: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 247
	i32 2801831435, ; 441: Microsoft.Maui.Graphics => 0xa7008e0b => 203
	i32 2803228030, ; 442: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 443: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 234
	i32 2819470561, ; 444: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 445: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 446: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 269
	i32 2824502124, ; 447: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2838993487, ; 448: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 258
	i32 2849599387, ; 449: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 450: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 281
	i32 2855708567, ; 451: Xamarin.AndroidX.Transition => 0xaa36a797 => 277
	i32 2861098320, ; 452: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 453: Microsoft.Maui.Essentials => 0xaa8a4878 => 202
	i32 2870099610, ; 454: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 219
	i32 2875164099, ; 455: Jsr305Binding.dll => 0xab5f85c3 => 286
	i32 2875220617, ; 456: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 457: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 245
	i32 2887636118, ; 458: System.Net.dll => 0xac1dd496 => 81
	i32 2893550578, ; 459: Google.Apis.Core => 0xac7813f2 => 177
	i32 2898407901, ; 460: System.Management => 0xacc231dd => 212
	i32 2899753641, ; 461: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 462: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 463: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 464: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 465: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 466: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 282
	i32 2919462931, ; 467: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 468: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 221
	i32 2936416060, ; 469: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 470: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 471: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 472: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 473: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2971004615, ; 474: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0xb115eec7 => 192
	i32 2972252294, ; 475: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 476: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 241
	i32 2980486542, ; 477: DyslexiaApp.MAUI => 0xb1a69d8e => 0
	i32 2987532451, ; 478: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 272
	i32 2990604888, ; 479: Google.Apis => 0xb2410258 => 175
	i32 2996846495, ; 480: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 254
	i32 3016983068, ; 481: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 274
	i32 3020703001, ; 482: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 185
	i32 3023353419, ; 483: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 484: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 249
	i32 3038032645, ; 485: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 332
	i32 3053864966, ; 486: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 304
	i32 3056245963, ; 487: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 271
	i32 3057625584, ; 488: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 262
	i32 3059408633, ; 489: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 490: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 491: System.Threading.Tasks => 0xb755818f => 144
	i32 3084678329, ; 492: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 197
	i32 3090735792, ; 493: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 494: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 495: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 496: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 497: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 498: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 499: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 500: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 501: GoogleGson.dll => 0xbba64c02 => 179
	i32 3159123045, ; 502: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 503: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3171180504, ; 504: MimeKit.dll => 0xbd045fd8 => 204
	i32 3178803400, ; 505: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 263
	i32 3192346100, ; 506: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 507: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 508: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 509: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 510: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 240
	i32 3220365878, ; 511: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 512: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 513: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 514: Xamarin.AndroidX.CardView => 0xc235e84d => 228
	i32 3265493905, ; 515: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 516: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3271840132, ; 517: StarkbankEcdsa.dll => 0xc3045184 => 209
	i32 3277815716, ; 518: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 519: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 520: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 521: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 522: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 523: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 524: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 304
	i32 3312457198, ; 525: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 195
	i32 3316684772, ; 526: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 527: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 238
	i32 3317144872, ; 528: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 529: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 226
	i32 3345895724, ; 530: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 267
	i32 3346324047, ; 531: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 264
	i32 3357674450, ; 532: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 321
	i32 3358260929, ; 533: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 534: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 219
	i32 3362522851, ; 535: Xamarin.AndroidX.Core => 0xc86c06e3 => 235
	i32 3366347497, ; 536: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 537: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 268
	i32 3381016424, ; 538: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 300
	i32 3395150330, ; 539: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 540: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 541: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 239
	i32 3421170118, ; 542: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 182
	i32 3428513518, ; 543: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 183
	i32 3429136800, ; 544: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 545: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 546: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 242
	i32 3445260447, ; 547: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 548: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 198
	i32 3453592554, ; 549: Google.Apis.Core.dll => 0xcdd9a3ea => 177
	i32 3458724246, ; 550: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 319
	i32 3471940407, ; 551: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 552: Mono.Android => 0xcf3163e6 => 171
	i32 3484440000, ; 553: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 320
	i32 3485117614, ; 554: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 555: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 556: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 231
	i32 3509114376, ; 557: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 558: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 559: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 560: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 561: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 562: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 563: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 328
	i32 3592228221, ; 564: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 330
	i32 3597029428, ; 565: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 217
	i32 3598340787, ; 566: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3605570793, ; 567: BouncyCastle.Cryptography => 0xd6e8a4e9 => 173
	i32 3608519521, ; 568: System.Linq.dll => 0xd715a361 => 61
	i32 3612435020, ; 569: System.Management.dll => 0xd751624c => 212
	i32 3624195450, ; 570: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 571: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 266
	i32 3633644679, ; 572: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 221
	i32 3638274909, ; 573: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 574: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 252
	i32 3643446276, ; 575: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 325
	i32 3643854240, ; 576: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 263
	i32 3645089577, ; 577: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 578: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 181
	i32 3660523487, ; 579: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 580: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 581: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 227
	i32 3684561358, ; 582: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 231
	i32 3700591436, ; 583: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 194
	i32 3700866549, ; 584: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 585: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 236
	i32 3716563718, ; 586: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 587: Xamarin.AndroidX.Annotation => 0xdda814c6 => 220
	i32 3724971120, ; 588: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 262
	i32 3732100267, ; 589: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 590: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 591: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 592: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3751619990, ; 593: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 300
	i32 3786282454, ; 594: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 229
	i32 3792276235, ; 595: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3793997468, ; 596: Google.Apis.Auth.dll => 0xe223ce9c => 176
	i32 3800979733, ; 597: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 198
	i32 3802395368, ; 598: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3807198597, ; 599: System.Security.Cryptography.Pkcs => 0xe2ed3d85 => 213
	i32 3819260425, ; 600: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 601: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 602: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 603: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 184
	i32 3844307129, ; 604: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 605: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3863245636, ; 606: DyslexiaApp.MAUI.dll => 0xe6447344 => 0
	i32 3870376305, ; 607: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 608: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 609: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 610: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 611: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 277
	i32 3888767677, ; 612: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 267
	i32 3896106733, ; 613: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 614: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 235
	i32 3901907137, ; 615: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920221145, ; 616: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 316
	i32 3920810846, ; 617: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 618: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 280
	i32 3928044579, ; 619: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 620: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 621: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 265
	i32 3945713374, ; 622: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 623: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 624: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 223
	i32 3959773229, ; 625: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 254
	i32 4003436829, ; 626: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 627: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 222
	i32 4025784931, ; 628: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 629: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 200
	i32 4054681211, ; 630: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4059682726, ; 631: Google.Apis.dll => 0xf1f9d7a6 => 175
	i32 4068434129, ; 632: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 633: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4082882467, ; 634: Google.Apis.Auth => 0xf35bd7a3 => 176
	i32 4091086043, ; 635: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 302
	i32 4094352644, ; 636: Microsoft.Maui.Essentials.dll => 0xf40add04 => 202
	i32 4099507663, ; 637: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 638: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 639: Xamarin.AndroidX.Emoji2 => 0xf479582c => 243
	i32 4103439459, ; 640: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 326
	i32 4126470640, ; 641: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 183
	i32 4127667938, ; 642: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 643: System.AppContext => 0xf6318da0 => 6
	i32 4144683026, ; 644: Refit.dll => 0xf70ad812 => 206
	i32 4147896353, ; 645: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 646: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 326
	i32 4151237749, ; 647: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 648: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 649: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 650: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 651: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 652: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 259
	i32 4185676441, ; 653: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 654: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 655: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4249188766, ; 656: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 315
	i32 4256097574, ; 657: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 236
	i32 4258378803, ; 658: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 258
	i32 4260525087, ; 659: System.Buffers => 0xfdf2741f => 7
	i32 4263231520, ; 660: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 211
	i32 4271975918, ; 661: Microsoft.Maui.Controls.dll => 0xfea12dee => 199
	i32 4274623895, ; 662: CommunityToolkit.Mvvm.dll => 0xfec99597 => 174
	i32 4274976490, ; 663: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 664: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 259
	i32 4294763496 ; 665: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 245
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [666 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 255, ; 3
	i32 289, ; 4
	i32 48, ; 5
	i32 297, ; 6
	i32 205, ; 7
	i32 80, ; 8
	i32 306, ; 9
	i32 145, ; 10
	i32 30, ; 11
	i32 330, ; 12
	i32 124, ; 13
	i32 203, ; 14
	i32 102, ; 15
	i32 314, ; 16
	i32 186, ; 17
	i32 273, ; 18
	i32 107, ; 19
	i32 273, ; 20
	i32 139, ; 21
	i32 293, ; 22
	i32 329, ; 23
	i32 322, ; 24
	i32 77, ; 25
	i32 124, ; 26
	i32 13, ; 27
	i32 229, ; 28
	i32 331, ; 29
	i32 132, ; 30
	i32 275, ; 31
	i32 151, ; 32
	i32 18, ; 33
	i32 227, ; 34
	i32 26, ; 35
	i32 185, ; 36
	i32 249, ; 37
	i32 1, ; 38
	i32 59, ; 39
	i32 42, ; 40
	i32 91, ; 41
	i32 232, ; 42
	i32 147, ; 43
	i32 207, ; 44
	i32 251, ; 45
	i32 248, ; 46
	i32 54, ; 47
	i32 187, ; 48
	i32 69, ; 49
	i32 327, ; 50
	i32 218, ; 51
	i32 83, ; 52
	i32 305, ; 53
	i32 250, ; 54
	i32 131, ; 55
	i32 55, ; 56
	i32 149, ; 57
	i32 74, ; 58
	i32 145, ; 59
	i32 62, ; 60
	i32 146, ; 61
	i32 332, ; 62
	i32 165, ; 63
	i32 325, ; 64
	i32 233, ; 65
	i32 12, ; 66
	i32 246, ; 67
	i32 125, ; 68
	i32 152, ; 69
	i32 113, ; 70
	i32 166, ; 71
	i32 164, ; 72
	i32 248, ; 73
	i32 194, ; 74
	i32 261, ; 75
	i32 303, ; 76
	i32 84, ; 77
	i32 193, ; 78
	i32 150, ; 79
	i32 293, ; 80
	i32 60, ; 81
	i32 324, ; 82
	i32 188, ; 83
	i32 51, ; 84
	i32 103, ; 85
	i32 114, ; 86
	i32 40, ; 87
	i32 286, ; 88
	i32 284, ; 89
	i32 120, ; 90
	i32 204, ; 91
	i32 52, ; 92
	i32 44, ; 93
	i32 119, ; 94
	i32 238, ; 95
	i32 316, ; 96
	i32 244, ; 97
	i32 81, ; 98
	i32 136, ; 99
	i32 280, ; 100
	i32 225, ; 101
	i32 8, ; 102
	i32 73, ; 103
	i32 155, ; 104
	i32 295, ; 105
	i32 154, ; 106
	i32 92, ; 107
	i32 290, ; 108
	i32 45, ; 109
	i32 213, ; 110
	i32 294, ; 111
	i32 109, ; 112
	i32 192, ; 113
	i32 178, ; 114
	i32 129, ; 115
	i32 25, ; 116
	i32 215, ; 117
	i32 72, ; 118
	i32 55, ; 119
	i32 46, ; 120
	i32 322, ; 121
	i32 191, ; 122
	i32 239, ; 123
	i32 22, ; 124
	i32 253, ; 125
	i32 86, ; 126
	i32 43, ; 127
	i32 160, ; 128
	i32 71, ; 129
	i32 266, ; 130
	i32 307, ; 131
	i32 3, ; 132
	i32 42, ; 133
	i32 63, ; 134
	i32 321, ; 135
	i32 16, ; 136
	i32 206, ; 137
	i32 53, ; 138
	i32 318, ; 139
	i32 289, ; 140
	i32 105, ; 141
	i32 205, ; 142
	i32 294, ; 143
	i32 311, ; 144
	i32 287, ; 145
	i32 250, ; 146
	i32 34, ; 147
	i32 158, ; 148
	i32 85, ; 149
	i32 32, ; 150
	i32 320, ; 151
	i32 12, ; 152
	i32 51, ; 153
	i32 56, ; 154
	i32 270, ; 155
	i32 36, ; 156
	i32 184, ; 157
	i32 288, ; 158
	i32 223, ; 159
	i32 35, ; 160
	i32 301, ; 161
	i32 58, ; 162
	i32 186, ; 163
	i32 257, ; 164
	i32 179, ; 165
	i32 17, ; 166
	i32 291, ; 167
	i32 164, ; 168
	i32 323, ; 169
	i32 317, ; 170
	i32 313, ; 171
	i32 256, ; 172
	i32 207, ; 173
	i32 190, ; 174
	i32 283, ; 175
	i32 319, ; 176
	i32 153, ; 177
	i32 279, ; 178
	i32 264, ; 179
	i32 209, ; 180
	i32 225, ; 181
	i32 29, ; 182
	i32 174, ; 183
	i32 52, ; 184
	i32 284, ; 185
	i32 331, ; 186
	i32 5, ; 187
	i32 299, ; 188
	i32 274, ; 189
	i32 278, ; 190
	i32 230, ; 191
	i32 295, ; 192
	i32 222, ; 193
	i32 241, ; 194
	i32 308, ; 195
	i32 85, ; 196
	i32 283, ; 197
	i32 61, ; 198
	i32 112, ; 199
	i32 328, ; 200
	i32 57, ; 201
	i32 329, ; 202
	i32 270, ; 203
	i32 99, ; 204
	i32 19, ; 205
	i32 234, ; 206
	i32 111, ; 207
	i32 101, ; 208
	i32 102, ; 209
	i32 297, ; 210
	i32 208, ; 211
	i32 104, ; 212
	i32 287, ; 213
	i32 71, ; 214
	i32 38, ; 215
	i32 32, ; 216
	i32 103, ; 217
	i32 73, ; 218
	i32 211, ; 219
	i32 303, ; 220
	i32 9, ; 221
	i32 123, ; 222
	i32 46, ; 223
	i32 224, ; 224
	i32 193, ; 225
	i32 9, ; 226
	i32 43, ; 227
	i32 4, ; 228
	i32 271, ; 229
	i32 195, ; 230
	i32 187, ; 231
	i32 327, ; 232
	i32 31, ; 233
	i32 138, ; 234
	i32 92, ; 235
	i32 93, ; 236
	i32 49, ; 237
	i32 141, ; 238
	i32 112, ; 239
	i32 140, ; 240
	i32 240, ; 241
	i32 115, ; 242
	i32 288, ; 243
	i32 157, ; 244
	i32 76, ; 245
	i32 79, ; 246
	i32 260, ; 247
	i32 37, ; 248
	i32 282, ; 249
	i32 244, ; 250
	i32 237, ; 251
	i32 64, ; 252
	i32 138, ; 253
	i32 15, ; 254
	i32 116, ; 255
	i32 276, ; 256
	i32 285, ; 257
	i32 232, ; 258
	i32 48, ; 259
	i32 70, ; 260
	i32 80, ; 261
	i32 126, ; 262
	i32 94, ; 263
	i32 121, ; 264
	i32 292, ; 265
	i32 26, ; 266
	i32 253, ; 267
	i32 97, ; 268
	i32 28, ; 269
	i32 228, ; 270
	i32 298, ; 271
	i32 149, ; 272
	i32 169, ; 273
	i32 4, ; 274
	i32 98, ; 275
	i32 33, ; 276
	i32 93, ; 277
	i32 275, ; 278
	i32 188, ; 279
	i32 21, ; 280
	i32 41, ; 281
	i32 170, ; 282
	i32 314, ; 283
	i32 246, ; 284
	i32 306, ; 285
	i32 260, ; 286
	i32 291, ; 287
	i32 285, ; 288
	i32 265, ; 289
	i32 2, ; 290
	i32 134, ; 291
	i32 111, ; 292
	i32 189, ; 293
	i32 215, ; 294
	i32 323, ; 295
	i32 58, ; 296
	i32 95, ; 297
	i32 305, ; 298
	i32 39, ; 299
	i32 226, ; 300
	i32 25, ; 301
	i32 94, ; 302
	i32 299, ; 303
	i32 89, ; 304
	i32 99, ; 305
	i32 10, ; 306
	i32 210, ; 307
	i32 87, ; 308
	i32 310, ; 309
	i32 100, ; 310
	i32 272, ; 311
	i32 180, ; 312
	i32 292, ; 313
	i32 217, ; 314
	i32 197, ; 315
	i32 302, ; 316
	i32 178, ; 317
	i32 7, ; 318
	i32 257, ; 319
	i32 214, ; 320
	i32 88, ; 321
	i32 182, ; 322
	i32 252, ; 323
	i32 154, ; 324
	i32 301, ; 325
	i32 33, ; 326
	i32 116, ; 327
	i32 82, ; 328
	i32 20, ; 329
	i32 11, ; 330
	i32 162, ; 331
	i32 3, ; 332
	i32 201, ; 333
	i32 309, ; 334
	i32 210, ; 335
	i32 191, ; 336
	i32 189, ; 337
	i32 84, ; 338
	i32 296, ; 339
	i32 64, ; 340
	i32 311, ; 341
	i32 208, ; 342
	i32 279, ; 343
	i32 143, ; 344
	i32 261, ; 345
	i32 157, ; 346
	i32 41, ; 347
	i32 117, ; 348
	i32 181, ; 349
	i32 216, ; 350
	i32 268, ; 351
	i32 131, ; 352
	i32 75, ; 353
	i32 66, ; 354
	i32 315, ; 355
	i32 172, ; 356
	i32 220, ; 357
	i32 143, ; 358
	i32 106, ; 359
	i32 151, ; 360
	i32 70, ; 361
	i32 309, ; 362
	i32 156, ; 363
	i32 196, ; 364
	i32 180, ; 365
	i32 121, ; 366
	i32 127, ; 367
	i32 310, ; 368
	i32 152, ; 369
	i32 243, ; 370
	i32 141, ; 371
	i32 230, ; 372
	i32 307, ; 373
	i32 20, ; 374
	i32 14, ; 375
	i32 135, ; 376
	i32 75, ; 377
	i32 59, ; 378
	i32 233, ; 379
	i32 167, ; 380
	i32 168, ; 381
	i32 199, ; 382
	i32 15, ; 383
	i32 74, ; 384
	i32 6, ; 385
	i32 173, ; 386
	i32 23, ; 387
	i32 313, ; 388
	i32 255, ; 389
	i32 214, ; 390
	i32 91, ; 391
	i32 308, ; 392
	i32 1, ; 393
	i32 136, ; 394
	i32 312, ; 395
	i32 256, ; 396
	i32 278, ; 397
	i32 134, ; 398
	i32 69, ; 399
	i32 146, ; 400
	i32 317, ; 401
	i32 296, ; 402
	i32 247, ; 403
	i32 190, ; 404
	i32 88, ; 405
	i32 96, ; 406
	i32 237, ; 407
	i32 242, ; 408
	i32 312, ; 409
	i32 31, ; 410
	i32 45, ; 411
	i32 251, ; 412
	i32 196, ; 413
	i32 216, ; 414
	i32 109, ; 415
	i32 158, ; 416
	i32 35, ; 417
	i32 22, ; 418
	i32 114, ; 419
	i32 57, ; 420
	i32 276, ; 421
	i32 144, ; 422
	i32 118, ; 423
	i32 120, ; 424
	i32 110, ; 425
	i32 218, ; 426
	i32 139, ; 427
	i32 224, ; 428
	i32 298, ; 429
	i32 54, ; 430
	i32 105, ; 431
	i32 318, ; 432
	i32 200, ; 433
	i32 201, ; 434
	i32 133, ; 435
	i32 290, ; 436
	i32 281, ; 437
	i32 269, ; 438
	i32 324, ; 439
	i32 247, ; 440
	i32 203, ; 441
	i32 159, ; 442
	i32 234, ; 443
	i32 163, ; 444
	i32 132, ; 445
	i32 269, ; 446
	i32 161, ; 447
	i32 258, ; 448
	i32 140, ; 449
	i32 281, ; 450
	i32 277, ; 451
	i32 169, ; 452
	i32 202, ; 453
	i32 219, ; 454
	i32 286, ; 455
	i32 40, ; 456
	i32 245, ; 457
	i32 81, ; 458
	i32 177, ; 459
	i32 212, ; 460
	i32 56, ; 461
	i32 37, ; 462
	i32 97, ; 463
	i32 166, ; 464
	i32 172, ; 465
	i32 282, ; 466
	i32 82, ; 467
	i32 221, ; 468
	i32 98, ; 469
	i32 30, ; 470
	i32 159, ; 471
	i32 18, ; 472
	i32 127, ; 473
	i32 192, ; 474
	i32 119, ; 475
	i32 241, ; 476
	i32 0, ; 477
	i32 272, ; 478
	i32 175, ; 479
	i32 254, ; 480
	i32 274, ; 481
	i32 185, ; 482
	i32 165, ; 483
	i32 249, ; 484
	i32 332, ; 485
	i32 304, ; 486
	i32 271, ; 487
	i32 262, ; 488
	i32 170, ; 489
	i32 16, ; 490
	i32 144, ; 491
	i32 197, ; 492
	i32 125, ; 493
	i32 118, ; 494
	i32 38, ; 495
	i32 115, ; 496
	i32 47, ; 497
	i32 142, ; 498
	i32 117, ; 499
	i32 34, ; 500
	i32 179, ; 501
	i32 95, ; 502
	i32 53, ; 503
	i32 204, ; 504
	i32 263, ; 505
	i32 129, ; 506
	i32 153, ; 507
	i32 24, ; 508
	i32 161, ; 509
	i32 240, ; 510
	i32 148, ; 511
	i32 104, ; 512
	i32 89, ; 513
	i32 228, ; 514
	i32 60, ; 515
	i32 142, ; 516
	i32 209, ; 517
	i32 100, ; 518
	i32 5, ; 519
	i32 13, ; 520
	i32 122, ; 521
	i32 135, ; 522
	i32 28, ; 523
	i32 304, ; 524
	i32 195, ; 525
	i32 72, ; 526
	i32 238, ; 527
	i32 24, ; 528
	i32 226, ; 529
	i32 267, ; 530
	i32 264, ; 531
	i32 321, ; 532
	i32 137, ; 533
	i32 219, ; 534
	i32 235, ; 535
	i32 168, ; 536
	i32 268, ; 537
	i32 300, ; 538
	i32 101, ; 539
	i32 123, ; 540
	i32 239, ; 541
	i32 182, ; 542
	i32 183, ; 543
	i32 163, ; 544
	i32 167, ; 545
	i32 242, ; 546
	i32 39, ; 547
	i32 198, ; 548
	i32 177, ; 549
	i32 319, ; 550
	i32 17, ; 551
	i32 171, ; 552
	i32 320, ; 553
	i32 137, ; 554
	i32 150, ; 555
	i32 231, ; 556
	i32 155, ; 557
	i32 130, ; 558
	i32 19, ; 559
	i32 65, ; 560
	i32 147, ; 561
	i32 47, ; 562
	i32 328, ; 563
	i32 330, ; 564
	i32 217, ; 565
	i32 79, ; 566
	i32 173, ; 567
	i32 61, ; 568
	i32 212, ; 569
	i32 106, ; 570
	i32 266, ; 571
	i32 221, ; 572
	i32 49, ; 573
	i32 252, ; 574
	i32 325, ; 575
	i32 263, ; 576
	i32 14, ; 577
	i32 181, ; 578
	i32 68, ; 579
	i32 171, ; 580
	i32 227, ; 581
	i32 231, ; 582
	i32 194, ; 583
	i32 78, ; 584
	i32 236, ; 585
	i32 108, ; 586
	i32 220, ; 587
	i32 262, ; 588
	i32 67, ; 589
	i32 63, ; 590
	i32 27, ; 591
	i32 160, ; 592
	i32 300, ; 593
	i32 229, ; 594
	i32 10, ; 595
	i32 176, ; 596
	i32 198, ; 597
	i32 11, ; 598
	i32 213, ; 599
	i32 78, ; 600
	i32 126, ; 601
	i32 83, ; 602
	i32 184, ; 603
	i32 66, ; 604
	i32 107, ; 605
	i32 0, ; 606
	i32 65, ; 607
	i32 128, ; 608
	i32 122, ; 609
	i32 77, ; 610
	i32 277, ; 611
	i32 267, ; 612
	i32 8, ; 613
	i32 235, ; 614
	i32 2, ; 615
	i32 316, ; 616
	i32 44, ; 617
	i32 280, ; 618
	i32 156, ; 619
	i32 128, ; 620
	i32 265, ; 621
	i32 23, ; 622
	i32 133, ; 623
	i32 223, ; 624
	i32 254, ; 625
	i32 29, ; 626
	i32 222, ; 627
	i32 62, ; 628
	i32 200, ; 629
	i32 90, ; 630
	i32 175, ; 631
	i32 87, ; 632
	i32 148, ; 633
	i32 176, ; 634
	i32 302, ; 635
	i32 202, ; 636
	i32 36, ; 637
	i32 86, ; 638
	i32 243, ; 639
	i32 326, ; 640
	i32 183, ; 641
	i32 50, ; 642
	i32 6, ; 643
	i32 206, ; 644
	i32 90, ; 645
	i32 326, ; 646
	i32 21, ; 647
	i32 162, ; 648
	i32 96, ; 649
	i32 50, ; 650
	i32 113, ; 651
	i32 259, ; 652
	i32 130, ; 653
	i32 76, ; 654
	i32 27, ; 655
	i32 315, ; 656
	i32 236, ; 657
	i32 258, ; 658
	i32 7, ; 659
	i32 211, ; 660
	i32 199, ; 661
	i32 174, ; 662
	i32 110, ; 663
	i32 259, ; 664
	i32 245 ; 665
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

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
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
