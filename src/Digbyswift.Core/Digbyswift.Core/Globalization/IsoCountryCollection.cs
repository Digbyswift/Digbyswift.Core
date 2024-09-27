﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Digbyswift.Core.Globalization;

public static class IsoCountryCollection
{
	public static IReadOnlyCollection<IsoCountry> Items { get; } = new Collection<IsoCountry>
	{
		new ("Afghanistan", "AF", "AFG", 4),
		new ("Åland Islands", "AX", "ALA", 248),
		new ("Albania", "AL", "ALB", 8),
		new ("Algeria", "DZ", "DZA", 12),
		new ("American Samoa", "AS", "ASM", 16),
		new ("Andorra", "AD", "AND", 20),
		new ("Angola", "AO", "AGO", 24),
		new ("Anguilla", "AI", "AIA", 660),
		new ("Antarctica", "AQ", "ATA", 10),
		new ("Antigua and Barbuda", "AG", "ATG", 28),
		new ("Argentina", "AR", "ARG", 32),
		new ("Armenia", "AM", "ARM", 51),
		new ("Aruba", "AW", "ABW", 533),
		new ("Australia", "AU", "AUS", 36),
		new ("Austria", "AT", "AUT", 40),
		new ("Azerbaijan", "AZ", "AZE", 31),
		new ("Bahamas", "BS", "BHS", 44),
		new ("Bahrain", "BH", "BHR", 48),
		new ("Bangladesh", "BD", "BGD", 50),
		new ("Barbados", "BB", "BRB", 52),
		new ("Belarus", "BY", "BLR", 112),
		new ("Belgium", "BE", "BEL", 56),
		new ("Belize", "BZ", "BLZ", 84),
		new ("Benin", "BJ", "BEN", 204),
		new ("Bermuda", "BM", "BMU", 60),
		new ("Bhutan", "BT", "BTN", 64),
		new ("Bolivia (Plurinational State of)", "BO", "BOL", 68),
		new ("Bonaire, Sint Eustatius and Saba", "BQ", "BES", 535),
		new ("Bosnia and Herzegovina", "BA", "BIH", 70),
		new ("Botswana", "BW", "BWA", 72),
		new ("Bouvet Island", "BV", "BVT", 74),
		new ("Brazil", "BR", "BRA", 76),
		new ("British Indian Ocean Territory", "IO", "IOT", 86),
		new ("Brunei Darussalam", "BN", "BRN", 96),
		new ("Bulgaria", "BG", "BGR", 100),
		new ("Burkina Faso", "BF", "BFA", 854),
		new ("Burundi", "BI", "BDI", 108),
		new ("Cabo Verde", "CV", "CPV", 132),
		new ("Cambodia", "KH", "KHM", 116),
		new ("Cameroon", "CM", "CMR", 120),
		new ("Canada", "CA", "CAN", 124),
		new ("Cayman Islands", "KY", "CYM", 136),
		new ("Central African Republic", "CF", "CAF", 140),
		new ("Chad", "TD", "TCD", 148),
		new ("Chile", "CL", "CHL", 152),
		new ("China", "CN", "CHN", 156),
		new ("Christmas Island", "CX", "CXR", 162),
		new ("Cocos (Keeling) Islands", "CC", "CCK", 166),
		new ("Colombia", "CO", "COL", 170),
		new ("Comoros", "KM", "COM", 174),
		new ("Congo", "CG", "COG", 178),
		new ("Congo, Democratic Republic of the", "CD", "COD", 180),
		new ("Cook Islands", "CK", "COK", 184),
		new ("Costa Rica", "CR", "CRI", 188),
		new ("Côte d'Ivoire", "CI", "CIV", 384),
		new ("Croatia", "HR", "HRV", 191),
		new ("Cuba", "CU", "CUB", 192),
		new ("Curaçao", "CW", "CUW", 531),
		new ("Cyprus", "CY", "CYP", 196),
		new ("Czechia", "CZ", "CZE", 203),
		new ("Denmark", "DK", "DNK", 208),
		new ("Djibouti", "DJ", "DJI", 262),
		new ("Dominica", "DM", "DMA", 212),
		new ("Dominican Republic", "DO", "DOM", 214),
		new ("Ecuador", "EC", "ECU", 218),
		new ("Egypt", "EG", "EGY", 818),
		new ("El Salvador", "SV", "SLV", 222),
		new ("Equatorial Guinea", "GQ", "GNQ", 226),
		new ("Eritrea", "ER", "ERI", 232),
		new ("Estonia", "EE", "EST", 233),
		new ("Eswatini", "SZ", "SWZ", 748),
		new ("Ethiopia", "ET", "ETH", 231),
		new ("Falkland Islands (Malvinas)", "FK", "FLK", 238),
		new ("Faroe Islands", "FO", "FRO", 234),
		new ("Fiji", "FJ", "FJI", 242),
		new ("Finland", "FI", "FIN", 246),
		new ("France", "FR", "FRA", 250),
		new ("French Guiana", "GF", "GUF", 254),
		new ("French Polynesia", "PF", "PYF", 258),
		new ("French Southern Territories", "TF", "ATF", 260),
		new ("Gabon", "GA", "GAB", 266),
		new ("Gambia", "GM", "GMB", 270),
		new ("Georgia", "GE", "GEO", 268),
		new ("Germany", "DE", "DEU", 276),
		new ("Ghana", "GH", "GHA", 288),
		new ("Gibraltar", "GI", "GIB", 292),
		new ("Greece", "GR", "GRC", 300),
		new ("Greenland", "GL", "GRL", 304),
		new ("Grenada", "GD", "GRD", 308),
		new ("Guadeloupe", "GP", "GLP", 312),
		new ("Guam", "GU", "GUM", 316),
		new ("Guatemala", "GT", "GTM", 320),
		new ("Guernsey", "GG", "GGY", 831),
		new ("Guinea", "GN", "GIN", 324),
		new ("Guinea-Bissau", "GW", "GNB", 624),
		new ("Guyana", "GY", "GUY", 328),
		new ("Haiti", "HT", "HTI", 332),
		new ("Heard Island and McDonald Islands", "HM", "HMD", 334),
		new ("Holy See", "VA", "VAT", 336),
		new ("Honduras", "HN", "HND", 340),
		new ("Hong Kong", "HK", "HKG", 344),
		new ("Hungary", "HU", "HUN", 348),
		new ("Iceland", "IS", "ISL", 352),
		new ("India", "IN", "IND", 356),
		new ("Indonesia", "ID", "IDN", 360),
		new ("Iran (Islamic Republic of)", "IR", "IRN", 364, shortName: "Iran"),
		new ("Iraq", "IQ", "IRQ", 368),
		new ("Ireland", "IE", "IRL", 372),
		new ("Isle of Man", "IM", "IMN", 833),
		new ("Israel", "IL", "ISR", 376),
		new ("Italy", "IT", "ITA", 380),
		new ("Jamaica", "JM", "JAM", 388),
		new ("Japan", "JP", "JPN", 392),
		new ("Jersey", "JE", "JEY", 832),
		new ("Jordan", "JO", "JOR", 400),
		new ("Kazakhstan", "KZ", "KAZ", 398),
		new ("Kenya", "KE", "KEN", 404),
		new ("Kiribati", "KI", "KIR", 296),
		new ("Korea (Democratic People's Republic of)", "KP", "PRK", 408, shortName: "North Korea"),
		new ("Korea, Republic of", "KR", "KOR", 410, shortName: "South Korea"),
		new ("Kuwait", "KW", "KWT", 414),
		new ("Kyrgyzstan", "KG", "KGZ", 417),
		new ("Lao People's Democratic Republic", "LA", "LAO", 418),
		new ("Latvia", "LV", "LVA", 428),
		new ("Lebanon", "LB", "LBN", 422),
		new ("Lesotho", "LS", "LSO", 426),
		new ("Liberia", "LR", "LBR", 430),
		new ("Libya", "LY", "LBY", 434),
		new ("Liechtenstein", "LI", "LIE", 438),
		new ("Lithuania", "LT", "LTU", 440),
		new ("Luxembourg", "LU", "LUX", 442),
		new ("Macao", "MO", "MAC", 446),
		new ("Madagascar", "MG", "MDG", 450),
		new ("Malawi", "MW", "MWI", 454),
		new ("Malaysia", "MY", "MYS", 458),
		new ("Maldives", "MV", "MDV", 462),
		new ("Mali", "ML", "MLI", 466),
		new ("Malta", "MT", "MLT", 470),
		new ("Marshall Islands", "MH", "MHL", 584),
		new ("Martinique", "MQ", "MTQ", 474),
		new ("Mauritania", "MR", "MRT", 478),
		new ("Mauritius", "MU", "MUS", 480),
		new ("Mayotte", "YT", "MYT", 175),
		new ("Mexico", "MX", "MEX", 484),
		new ("Micronesia (Federated States of)", "FM", "FSM", 583),
		new ("Moldova, Republic of", "MD", "MDA", 498),
		new ("Monaco", "MC", "MCO", 492),
		new ("Mongolia", "MN", "MNG", 496),
		new ("Montenegro", "ME", "MNE", 499),
		new ("Montserrat", "MS", "MSR", 500),
		new ("Morocco", "MA", "MAR", 504),
		new ("Mozambique", "MZ", "MOZ", 508),
		new ("Myanmar", "MM", "MMR", 104),
		new ("Namibia", "NA", "NAM", 516),
		new ("Nauru", "NR", "NRU", 520),
		new ("Nepal", "NP", "NPL", 524),
		new ("Netherlands", "NL", "NLD", 528),
		new ("New Caledonia", "NC", "NCL", 540),
		new ("New Zealand", "NZ", "NZL", 554),
		new ("Nicaragua", "NI", "NIC", 558),
		new ("Niger", "NE", "NER", 562),
		new ("Nigeria", "NG", "NGA", 566),
		new ("Niue", "NU", "NIU", 570),
		new ("Norfolk Island", "NF", "NFK", 574),
		new ("North Macedonia", "MK", "MKD", 807),
		new ("Northern Mariana Islands", "MP", "MNP", 580),
		new ("Norway", "NO", "NOR", 578),
		new ("Oman", "OM", "OMN", 512),
		new ("Pakistan", "PK", "PAK", 586),
		new ("Palau", "PW", "PLW", 585),
		new ("Palestine, State of", "PS", "PSE", 275),
		new ("Panama", "PA", "PAN", 591),
		new ("Papua New Guinea", "PG", "PNG", 598),
		new ("Paraguay", "PY", "PRY", 600),
		new ("Peru", "PE", "PER", 604),
		new ("Philippines", "PH", "PHL", 608),
		new ("Pitcairn", "PN", "PCN", 612),
		new ("Poland", "PL", "POL", 616),
		new ("Portugal", "PT", "PRT", 620),
		new ("Puerto Rico", "PR", "PRI", 630),
		new ("Qatar", "QA", "QAT", 634),
		new ("Réunion", "RE", "REU", 638),
		new ("Romania", "RO", "ROU", 642),
		new ("Russian Federation", "RU", "RUS", 643),
		new ("Rwanda", "RW", "RWA", 646),
		new ("Saint Barthélemy", "BL", "BLM", 652),
		new ("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", 654),
		new ("Saint Kitts and Nevis", "KN", "KNA", 659),
		new ("Saint Lucia", "LC", "LCA", 662),
		new ("Saint Martin (French part)", "MF", "MAF", 663),
		new ("Saint Pierre and Miquelon", "PM", "SPM", 666),
		new ("Saint Vincent and the Grenadines", "VC", "VCT", 670),
		new ("Samoa", "WS", "WSM", 882),
		new ("San Marino", "SM", "SMR", 674),
		new ("Sao Tome and Principe", "ST", "STP", 678),
		new ("Saudi Arabia", "SA", "SAU", 682),
		new ("Senegal", "SN", "SEN", 686),
		new ("Serbia", "RS", "SRB", 688),
		new ("Seychelles", "SC", "SYC", 690),
		new ("Sierra Leone", "SL", "SLE", 694),
		new ("Singapore", "SG", "SGP", 702),
		new ("Sint Maarten (Dutch part)", "SX", "SXM", 534),
		new ("Slovakia", "SK", "SVK", 703),
		new ("Slovenia", "SI", "SVN", 705),
		new ("Solomon Islands", "SB", "SLB", 90),
		new ("Somalia", "SO", "SOM", 706),
		new ("South Africa", "ZA", "ZAF", 710),
		new ("South Georgia and the South Sandwich Islands", "GS", "SGS", 239),
		new ("South Sudan", "SS", "SSD", 728),
		new ("Spain", "ES", "ESP", 724),
		new ("Sri Lanka", "LK", "LKA", 144),
		new ("Sudan", "SD", "SDN", 729),
		new ("Suriname", "SR", "SUR", 740),
		new ("Svalbard and Jan Mayen", "SJ", "SJM", 744),
		new ("Sweden", "SE", "SWE", 752),
		new ("Switzerland", "CH", "CHE", 756),
		new ("Syrian Arab Republic", "SY", "SYR", 760),
		new ("Taiwan, Province of China", "TW", "TWN", 158),
		new ("Tajikistan", "TJ", "TJK", 762),
		new ("Tanzania, United Republic of", "TZ", "TZA", 834, shortName: "Tanzania"),
		new ("Thailand", "TH", "THA", 764),
		new ("Timor-Leste", "TL", "TLS", 626),
		new ("Togo", "TG", "TGO", 768),
		new ("Tokelau", "TK", "TKL", 772),
		new ("Tonga", "TO", "TON", 776),
		new ("Trinidad and Tobago", "TT", "TTO", 780),
		new ("Tunisia", "TN", "TUN", 788),
		new ("Turkey", "TR", "TUR", 792),
		new ("Turkmenistan", "TM", "TKM", 795),
		new ("Turks and Caicos Islands", "TC", "TCA", 796),
		new ("Tuvalu", "TV", "TUV", 798),
		new ("Uganda", "UG", "UGA", 800),
		new ("Ukraine", "UA", "UKR", 804),
		new ("United Arab Emirates", "AE", "ARE", 784, abbreviation: "UAE"),
		new ("United Kingdom of Great Britain and Northern Ireland", "GB", "GBR", 826, shortName: "United Kingdom", abbreviation: "UK"),
		new ("United States of America", "US", "USA", 840, shortName: "United States", abbreviation: "US"),
		new ("United States Minor Outlying Islands", "UM", "UMI", 581),
		new ("Uruguay", "UY", "URY", 858),
		new ("Uzbekistan", "UZ", "UZB", 860),
		new ("Vanuatu", "VU", "VUT", 548),
		new ("Venezuela (Bolivarian Republic of)", "VE", "VEN", 862, shortName: "Venezuela"),
		new ("Viet Nam", "VN", "VNM", 704),
		new ("Virgin Islands (British)", "VG", "VGB", 92),
		new ("Virgin Islands (U.S.)", "VI", "VIR", 850),
		new ("Wallis and Futuna", "WF", "WLF", 876),
		new ("Western Sahara", "EH", "ESH", 732),
		new ("Yemen", "YE", "YEM", 887),
		new ("Zambia", "ZM", "ZMB", 894),
		new ("Zimbabwe", "ZW", "ZWE", 716)
	};
}