using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDojo.Migrations
{
    public partial class avecDonnees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samourais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Force = table.Column<int>(type: "int", nullable: false),
                    ArmeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samourais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samourais_Armes_ArmeId",
                        column: x => x.ArmeId,
                        principalTable: "Armes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 1, null, 1254, "Abe Masakatsu" },
                    { 2, null, 748, "Adachi Yasumori" },
                    { 3, null, 732, "Adachi Kagemori" },
                    { 4, null, 1579, "Adams William" },
                    { 5, null, 1885, "Aiou Mototsuna" },
                    { 6, null, 1467, "Akai Terukage" },
                    { 7, null, 24, "Akao Kiyotsuna" },
                    { 8, null, 644, "Akechi Mitsuhide" },
                    { 9, null, 1176, "Akiyama Nobutomo" },
                    { 10, null, 504, "Amago Haruhisa" },
                    { 11, null, 416, "Amago Yoshihisa" },
                    { 12, null, 1677, "Andō Morinari" },
                    { 13, null, 328, "Ankokuji Ekei" },
                    { 14, null, 1399, "Aochi Shigetsuna" },
                    { 15, null, 22, "Aokage Takaakira" },
                    { 16, null, 2, "Aoki Kazushige" },
                    { 17, null, 1296, "Akahori Chohichi" },
                    { 18, null, 1967, "Arai Hakuseki" },
                    { 19, null, 1968, "Araki Motokiyo" },
                    { 20, null, 612, "Araki Murashige" },
                    { 21, null, 668, "Araki Muratsugu" },
                    { 22, null, 1779, "Arima Kihei" },
                    { 23, null, 1387, "Asakura Yoshikage" },
                    { 24, null, 1531, "Ayame Kagekatsu" },
                    { 25, null, 514, "Azai Hisamasa" },
                    { 26, null, 461, "Azai Nagamasa" },
                    { 27, null, 321, "Azai Sukemasa" },
                    { 28, null, 1180, "Baba Nobufusa" },
                    { 29, null, 1422, "Bessho Nagaharu" },
                    { 30, null, 685, "Chacha" },
                    { 31, null, 1742, "Chiba Shusaku Narimasa" },
                    { 32, null, 1571, "Chōsokabe Morichika" },
                    { 33, null, 1171, "Chōsokabe Kunichika" },
                    { 34, null, 1600, "Chōsokabe Motochika" },
                    { 35, null, 1571, "Chōsokabe Nobuchika" },
                    { 36, null, 1840, "Collache Eugène" },
                    { 37, null, 1849, "Date Masamune" },
                    { 38, null, 1085, "Date Shigezane" },
                    { 39, null, 1283, "Doi Toshikatsu" },
                    { 40, null, 1834, "Etō Shinpei" },
                    { 41, null, 1973, "Endō Naotsune" },
                    { 42, null, 854, "Enjoji Nobutane" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 43, null, 1435, "Enomoto Takeaki" },
                    { 44, null, 941, "Era Fusahide" },
                    { 45, null, 1425, "Fūma Kotarō" },
                    { 46, null, 24, "Fuwa Mitsuharu" },
                    { 47, null, 1225, "Fukushima Masanori" },
                    { 48, null, 1004, "Gamō Katahide" },
                    { 49, null, 1198, "Gamō Ujisato" },
                    { 50, null, 1489, "Harada Naomasa" },
                    { 51, null, 162, "Harada Nobutane" },
                    { 52, null, 406, "Harada Sanosuke" },
                    { 53, null, 652, "Hasekura Tsunenaga" },
                    { 54, null, 1163, "Hattori Hanzō" },
                    { 55, null, 358, "Hatano Hideharu" },
                    { 56, null, 236, "Hasegawa Eishin" },
                    { 57, null, 415, "Hayashizaki Jinsuke Shigenobu" },
                    { 58, null, 1111, "Hayashi Narinaga" },
                    { 59, null, 848, "Hijikata Toshizo" },
                    { 60, null, 1383, "Hirate Masahide" },
                    { 61, null, 324, "Hitotsubashi Keiki" },
                    { 62, null, 876, "Hōjō Masako" },
                    { 63, null, 1577, "Hōjō Tokimune" },
                    { 64, null, 1158, "Hōjō Ujiyasu" },
                    { 65, null, 191, "Hōjō Ujimasa" },
                    { 66, null, 657, "Honda Tadakatsu" },
                    { 67, null, 909, "Honda Tadatomo" },
                    { 68, null, 1052, "Honganji Kennyo" },
                    { 69, null, 1143, "Horio Yoshiharu" },
                    { 70, null, 141, "Hosokawa Fujitaka" },
                    { 71, null, 1111, "Hosokawa Gracia" },
                    { 72, null, 710, "Hosokawa Tadaoki" },
                    { 73, null, 175, "Hotta Masatoshi" },
                    { 74, null, 1899, "Ii Naoaki" },
                    { 75, null, 1801, "Ii Naomasa" },
                    { 76, null, 1206, "Ii Naomori" },
                    { 77, null, 1563, "Ii Naonaka" },
                    { 78, null, 1167, "Ii Naosuke" },
                    { 79, null, 1722, "Ii Naotaka" },
                    { 80, null, 1513, "Ii Naotora" },
                    { 81, null, 1130, "Ii Naoyuki" },
                    { 82, null, 1439, "Ii Naozumi" },
                    { 83, null, 773, "Iizasa Ienao" },
                    { 84, null, 1550, "Ijuin Tadaaki" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 85, null, 282, "Ikeda Tsuneoki" },
                    { 86, null, 1936, "Imagawa Ujizane" },
                    { 87, null, 13, "Imagawa Yoshimoto" },
                    { 88, null, 1637, "Imai Kanehira" },
                    { 89, null, 1186, "Inaba Yoshimichi" },
                    { 90, null, 800, "Inugami Nagayasu" },
                    { 91, null, 6, "Ishida Mitsunari" },
                    { 92, null, 167, "Isshiki Fujinaga" },
                    { 93, null, 187, "Itagaki Nobukata" },
                    { 94, null, 1500, "Itō Hirobumi" },
                    { 95, null, 399, "Iwanari Tomomichi" },
                    { 96, null, 1388, "Jinbo Nagamoto" },
                    { 97, null, 1271, "Jonas Tönse" },
                    { 98, null, 225, "Kannan Kumar(Salem)" },
                    { 99, null, 1082, "Kakeda Toshimune" },
                    { 100, null, 1826, "Kaneko Ietada" },
                    { 101, null, 422, "Katagiri Katsumoto" },
                    { 102, null, 1357, "Katakura Kojūro" },
                    { 103, null, 1236, "Katakura Shigenaga" },
                    { 104, null, 1304, "Kataoka Mitsumasa" },
                    { 105, null, 1846, "Katō Kiyomasa" },
                    { 106, null, 158, "Kawakami Gensai" },
                    { 107, null, 1751, "Kido Takayoshi" },
                    { 108, null, 1919, "Kikkawa Hiroie" },
                    { 109, null, 421, "Kimotsuki Kanetsugu" },
                    { 110, null, 451, "Kitamura Kansuke" },
                    { 111, null, 478, "Kobayakawa Hideaki" },
                    { 112, null, 1617, "Kobayakawa Hidekane" },
                    { 113, null, 855, "Kobayakawa Takakage" },
                    { 114, null, 105, "Konishi Yukinaga" },
                    { 115, null, 1857, "Kojima Toyoharu" },
                    { 116, null, 1652, "Kuroda Kanbei" },
                    { 117, null, 577, "Kuroda Kiyotaka" },
                    { 118, null, 869, "Kusunoki Masashige" },
                    { 119, null, 714, "Kuwana Tarozaemon" },
                    { 120, null, 1197, "Kumagai Naozane" },
                    { 121, null, 34, "Maeda Keiji" },
                    { 122, null, 1653, "Maeda Matsu" },
                    { 123, null, 1442, "Maeda Nagatane" },
                    { 124, null, 1098, "Maeda Toshiie" },
                    { 125, null, 426, "Maeda Toshinaga" },
                    { 126, null, 270, "Maeda Toshitsune" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 127, null, 689, "Magome Kageyu" },
                    { 128, null, 1882, "Manabe Akifusa" },
                    { 129, null, 310, "Matsudaira Katamori" },
                    { 130, null, 699, "Matsudaira Nobutsuna" },
                    { 131, null, 1260, "Matsudaira Nobuyasu" },
                    { 132, null, 1242, "Matsudaira Higo no Kami Katamori" },
                    { 133, null, 1943, "Matsudaira Sadanobu" },
                    { 134, null, 1121, "Matsudaira Tadayoshi" },
                    { 135, null, 954, "Matsudaira Teru" },
                    { 136, null, 1351, "Matsunaga Hisahide" },
                    { 137, null, 645, "Matsunaga Hisamichi" },
                    { 138, null, 1896, "Matsuo Bashō" },
                    { 139, null, 1303, "Matsudaira Motoyasu" },
                    { 140, null, 105, "Minamoto no Mitsunaka" },
                    { 141, null, 1013, "Minamoto no Yoshiie" },
                    { 142, null, 1227, "Minamoto no Yoshimitsu" },
                    { 143, null, 598, "Minamoto no Yoshinaka" },
                    { 144, null, 308, "Minamoto no Yoshitomo" },
                    { 145, null, 201, "Minamoto no Yoshitsune" },
                    { 146, null, 736, "Minamoto no Tameyoshi" },
                    { 147, null, 1520, "Minamoto no Yorimasa" },
                    { 148, null, 1882, "Minamoto no Yorimitsu" },
                    { 149, null, 308, "Minamoto no Yoritomo" },
                    { 150, null, 795, "Minamoto no Noriyori" },
                    { 151, null, 1696, "Minoro Takashi" },
                    { 152, null, 795, "Miura Anjin" },
                    { 153, null, 71, "Miura Yoshimoto" },
                    { 154, null, 559, "Miyamoto Musashi" },
                    { 155, null, 1464, "Miyoshi Chōkei" },
                    { 156, null, 805, "Miyoshi Kazuhide" },
                    { 157, null, 143, "Miyoshi Masaga" },
                    { 158, null, 1924, "Miyoshi Masayasu" },
                    { 159, null, 796, "Miyoshi Moriyata" },
                    { 160, null, 495, "Miyoshi Nagayuki" },
                    { 161, null, 1263, "Miyoshi Yoshitsugu" },
                    { 162, null, 1931, "Mizuno Tadakuni" },
                    { 163, null, 990, "Moniwa Yoshinao" },
                    { 164, null, 1042, "Mōri Motonari" },
                    { 165, null, 436, "Mōri Nagasada" },
                    { 166, null, 109, "Mori Nagayoshi" },
                    { 167, null, 119, "Mōri Okimoto" },
                    { 168, null, 1867, "Mori Ranmaru" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 169, null, 247, "Mōri Takamoto" },
                    { 170, null, 1429, "Mori Tadamasa" },
                    { 171, null, 1160, "Mōri Terumoto" },
                    { 172, null, 260, "Mori Yoshinari" },
                    { 173, null, 1591, "Murai Sadakatsu" },
                    { 174, null, 1054, "Nagakura Shinpachi" },
                    { 175, null, 1625, "Nagao Harukage" },
                    { 176, null, 586, "Nagao Kagenobu" },
                    { 177, null, 1540, "Nagao Masakage" },
                    { 178, null, 1055, "Nagao Tamekage" },
                    { 179, null, 1535, "Nakagawa Kiyohide" },
                    { 180, null, 382, "Nakaoka Shintarō" },
                    { 181, null, 433, "Naoe Kagetsuna" },
                    { 182, null, 1296, "Naoe Kanetsugu" },
                    { 183, null, 1292, "Narita Kaihime" },
                    { 184, null, 77, "Nene" },
                    { 185, null, 765, "Nihonmatsu Yoshitsugu" },
                    { 186, null, 1558, "Niimi Nishiki" },
                    { 187, null, 417, "Niiro Tadamoto" },
                    { 188, null, 1541, "Niwa Nagahide" },
                    { 189, null, 1156, "Niwa Nagashige" },
                    { 190, null, 1745, "Oda Hiroyoshi" },
                    { 191, null, 1225, "Oda Nobuhide" },
                    { 192, null, 37, "Oda Nobukata" },
                    { 193, null, 873, "Oda Nobukiyo" },
                    { 194, null, 1353, "Oda Nobunaga" },
                    { 195, null, 1680, "Oda Nobutada" },
                    { 196, null, 747, "Oda Nobutomo" },
                    { 197, null, 1479, "Oda Nobukatsu" },
                    { 198, null, 1520, "Oda Nobuyasu" },
                    { 199, null, 675, "Ogasawara Shōsai" },
                    { 200, null, 1889, "Ōishi Kuranosuke" },
                    { 201, null, 101, "Okada Izō" },
                    { 202, null, 1735, "Judge Ooka" },
                    { 203, null, 1659, "Ōta Dōkan" },
                    { 204, null, 556, "Ōtani Yoshitsugu" },
                    { 205, null, 107, "Ōtani Yoshiharu" },
                    { 206, null, 830, "Ōtomo Sōrin" },
                    { 207, null, 773, "Okita Sōji" },
                    { 208, null, 913, "Ōkubo Toshimichi" },
                    { 209, null, 641, "Okunomiya Masaie" },
                    { 210, null, 167, "Ōuchi Yoshitaka" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 211, null, 212, "Omy Yoshika" },
                    { 212, null, 1902, "Pore Sufi" },
                    { 213, null, 621, "Reizei Takatoyo" },
                    { 214, null, 1883, "Rokkaku Sadayori" },
                    { 215, null, 149, "Rokkaku Yoshiharu" },
                    { 216, null, 589, "Rokkaku Yoshikata" },
                    { 217, null, 313, "Rusu Masakage" },
                    { 218, null, 14, "Ryūzōji Takanobu" },
                    { 219, null, 944, "Saigo Kiyokazu" },
                    { 220, null, 1340, "Saigō Masako" },
                    { 221, null, 987, "Sagara Taketō" },
                    { 222, null, 1197, "Saigō Takamori" },
                    { 223, null, 902, "Saigo Yoshikatsu" },
                    { 224, null, 1673, "Saitō Dōsan" },
                    { 225, null, 741, "Saitō Hajime" },
                    { 226, null, 1603, "Saito Musashibō Benkei" },
                    { 227, null, 829, "Saitō Yoshitatsu" },
                    { 228, null, 931, "Sakai Tadakiyo" },
                    { 229, null, 558, "Sakai Tadashige" },
                    { 230, null, 1239, "Sakai Tadatsugu" },
                    { 231, null, 820, "Sakai Tadayo" },
                    { 232, null, 1396, "Sakakibara Yasumasa" },
                    { 233, null, 386, "Sakamoto Ryōma" },
                    { 234, null, 706, "Sakuma Morimasa" },
                    { 235, null, 801, "Sakuma Nobumori" },
                    { 236, null, 1460, "Sanada Akihime" },
                    { 237, null, 1335, "Sanada Komatsuhime" },
                    { 238, null, 847, "Sanada Masayuki" },
                    { 239, null, 1138, "Sanada Nobuyuki" },
                    { 240, null, 951, "Sanada Yukimura" },
                    { 241, null, 153, "Sasaki Kojirō" },
                    { 242, null, 1565, "Sassa Narimasa" },
                    { 243, null, 730, "Sasuke Sarutobi" },
                    { 244, null, 745, "Serizawa Kamo" },
                    { 245, null, 535, "Shibata Katsuie" },
                    { 246, null, 561, "Shima Sakon" },
                    { 247, null, 565, "Shimada Ichirō" },
                    { 248, null, 1018, "Shimazu Katsuhisa" },
                    { 249, null, 592, "Shimazu Tadahisa" },
                    { 250, null, 417, "Shimazu Tadatsune" },
                    { 251, null, 1453, "Shimazu Tadayoshi" },
                    { 252, null, 305, "Shimazu Takahisa" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 253, null, 1928, "Shimazu Toyohisa" },
                    { 254, null, 286, "Shimazu Yoshihiro" },
                    { 255, null, 783, "Shimazu Yoshihisa" },
                    { 256, null, 1653, "Shindou Hiroshii" },
                    { 257, null, 1612, "Sogo Nagayasu" },
                    { 258, null, 1167, "Sue Yoshitaka" },
                    { 259, null, 1568, "Tachibana Muneshige" },
                    { 260, null, 1490, "Tachibana Dōsetsu" },
                    { 261, null, 1214, "Tachibana Ginchiyo" },
                    { 262, null, 1914, "Taigen Sessai" },
                    { 263, null, 1791, "Taira no Kiyomori" },
                    { 264, null, 314, "Taira Masakado" },
                    { 265, null, 1108, "Takahashi Shigetane" },
                    { 266, null, 6, "Takenaka Shigeharu" },
                    { 267, null, 175, "Takasugi Shinsaku" },
                    { 268, null, 246, "Takayama Justo" },
                    { 269, null, 1055, "Takayama Ukon" },
                    { 270, null, 282, "Takechi Hanpeita" },
                    { 271, null, 271, "Takeda Katsuyori" },
                    { 272, null, 767, "Takeda Nobukatsu" },
                    { 273, null, 72, "Takeda Nobushige" },
                    { 274, null, 1586, "Takeda Shingen" },
                    { 275, null, 490, "Takenaka Hanbei" },
                    { 276, null, 1766, "Tani Tadasumi" },
                    { 277, null, 1872, "Tōdō Takatora" },
                    { 278, null, 618, "Toki Yorinari" },
                    { 279, null, 1424, "Tochimitsu Gantyoki" },
                    { 280, null, 1113, "Tokugawa Ieyasu" },
                    { 281, null, 122, "Tokugawa Hidetada" },
                    { 282, null, 1801, "Tokugawa Nariaki" },
                    { 283, null, 489, "Tokugawa Yoshinobu" },
                    { 284, null, 1018, "Torii Mototada" },
                    { 285, null, 1954, "Toyotomi Hidenaga" },
                    { 286, null, 39, "Toyotomi Hideyoshi" },
                    { 287, null, 1396, "Toyotomi Hideyori" },
                    { 288, null, 131, "Tozuka Tadaharu" },
                    { 289, null, 767, "Tsukahara Bokuden" },
                    { 290, null, 1317, "Uesugi Kagekatsu" },
                    { 291, null, 1285, "Uesugi Kagetora" },
                    { 292, null, 716, "Uesugi Kenshin" },
                    { 293, null, 464, "Ujiie Naotomo" },
                    { 294, null, 496, "Ukita Naoie" }
                });

            migrationBuilder.InsertData(
                table: "Samourais",
                columns: new[] { "Id", "ArmeId", "Force", "Nom" },
                values: new object[,]
                {
                    { 295, null, 532, "Ukita Okiie" },
                    { 296, null, 1694, "Umezawa Michiharu" },
                    { 297, null, 89, "Usami Sadamitsu" },
                    { 298, null, 374, "Uyama Hisanobu" },
                    { 299, null, 1866, "Wada Shinsuke" },
                    { 300, null, 1866, "Watanabe Kazan" },
                    { 301, null, 1867, "Watanabe no Tsuna" },
                    { 302, null, 1349, "Yasumero Kenshin" },
                    { 303, null, 955, "Yagyū Jūbei Mitsuyoshi" },
                    { 304, null, 128, "Yagyū Munenori" },
                    { 305, null, 444, "Yamauchi Kazutoyo" },
                    { 306, null, 683, "Yamada Arinaga" },
                    { 307, null, 1013, "Yamada Arinobu" },
                    { 308, null, 942, "Yamada Nagamasa" },
                    { 309, null, 1000, "Yamagata Masakage" },
                    { 310, null, 1914, "Yamakawa Hiroshi" },
                    { 311, null, 1582, "Yamakawa Kenjirō" },
                    { 312, null, 876, "Yamakawa Naoe" },
                    { 313, null, 1802, "Yamanaka Yukimori" },
                    { 314, null, 1316, "Yamanami Keisuke" },
                    { 315, null, 1675, "Yamaoka Tesshū" },
                    { 316, null, 350, "Yanagawa Kenzaburo" },
                    { 317, null, 1634, "Yanagisawa Yoshiyasu" },
                    { 318, null, 943, "Yonekura Shigetsugu" },
                    { 319, null, 702, "Yūki Hideyasu" },
                    { 320, null, 470, "Yasuke" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samourais_ArmeId",
                table: "Samourais",
                column: "ArmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samourais");

            migrationBuilder.DropTable(
                name: "Armes");
        }
    }
}
