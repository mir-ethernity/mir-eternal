using System;

namespace GameServer
{
	// Token: 0x02000050 RID: 80
	public enum ObjectFaceType
	{
		// Token: 0x0400025E RID: 606
		战士男00 = 256,
		// Token: 0x0400025F RID: 607
		战士男01,
		// Token: 0x04000260 RID: 608
		战士男02,
		// Token: 0x04000261 RID: 609
		战士男03,
		// Token: 0x04000262 RID: 610
		战士男04,
		// Token: 0x04000263 RID: 611
		战士男05,
		// Token: 0x04000264 RID: 612
		战士男06,
		// Token: 0x04000265 RID: 613
		战士男07,
		// Token: 0x04000266 RID: 614
		战士女00 = 512,
		// Token: 0x04000267 RID: 615
		战士女01,
		// Token: 0x04000268 RID: 616
		战士女02,
		// Token: 0x04000269 RID: 617
		战士女03,
		// Token: 0x0400026A RID: 618
		战士女04,
		// Token: 0x0400026B RID: 619
		战士女05,
		// Token: 0x0400026C RID: 620
		战士女06,
		// Token: 0x0400026D RID: 621
		战士女07,
		// Token: 0x0400026E RID: 622
		法师男00 = 65792,
		// Token: 0x0400026F RID: 623
		法师男01,
		// Token: 0x04000270 RID: 624
		法师男02,
		// Token: 0x04000271 RID: 625
		法师男03,
		// Token: 0x04000272 RID: 626
		法师男04,
		// Token: 0x04000273 RID: 627
		法师男05,
		// Token: 0x04000274 RID: 628
		法师男06,
		// Token: 0x04000275 RID: 629
		法师男07,
		// Token: 0x04000276 RID: 630
		法师女00 = 66048,
		// Token: 0x04000277 RID: 631
		法师女01,
		// Token: 0x04000278 RID: 632
		法师女02,
		// Token: 0x04000279 RID: 633
		法师女03,
		// Token: 0x0400027A RID: 634
		法师女04,
		// Token: 0x0400027B RID: 635
		法师女05,
		// Token: 0x0400027C RID: 636
		法师女06,
		// Token: 0x0400027D RID: 637
		法师女07,
		// Token: 0x0400027E RID: 638
		道士男00 = 262400,
		// Token: 0x0400027F RID: 639
		道士男01,
		// Token: 0x04000280 RID: 640
		道士男02,
		// Token: 0x04000281 RID: 641
		道士男03,
		// Token: 0x04000282 RID: 642
		道士男04,
		// Token: 0x04000283 RID: 643
		道士男05,
		// Token: 0x04000284 RID: 644
		道士男06,
		// Token: 0x04000285 RID: 645
		道士男07,
		// Token: 0x04000286 RID: 646
		道士女00 = 262656,
		// Token: 0x04000287 RID: 647
		道士女01,
		// Token: 0x04000288 RID: 648
		道士女02,
		// Token: 0x04000289 RID: 649
		道士女03,
		// Token: 0x0400028A RID: 650
		道士女04,
		// Token: 0x0400028B RID: 651
		道士女05,
		// Token: 0x0400028C RID: 652
		道士女06,
		// Token: 0x0400028D RID: 653
		道士女07,
		// Token: 0x0400028E RID: 654
		刺客男00 = 131328,
		// Token: 0x0400028F RID: 655
		刺客男01,
		// Token: 0x04000290 RID: 656
		刺客男02,
		// Token: 0x04000291 RID: 657
		刺客男03,
		// Token: 0x04000292 RID: 658
		刺客男04,
		// Token: 0x04000293 RID: 659
		刺客男05,
		// Token: 0x04000294 RID: 660
		刺客男06,
		// Token: 0x04000295 RID: 661
		刺客男07,
		// Token: 0x04000296 RID: 662
		刺客女00 = 131584,
		// Token: 0x04000297 RID: 663
		刺客女01,
		// Token: 0x04000298 RID: 664
		刺客女02,
		// Token: 0x04000299 RID: 665
		刺客女03,
		// Token: 0x0400029A RID: 666
		刺客女04,
		// Token: 0x0400029B RID: 667
		刺客女05,
		// Token: 0x0400029C RID: 668
		刺客女06,
		// Token: 0x0400029D RID: 669
		刺客女07,
		// Token: 0x0400029E RID: 670
		弓手男00 = 196864,
		// Token: 0x0400029F RID: 671
		弓手男01,
		// Token: 0x040002A0 RID: 672
		弓手男02,
		// Token: 0x040002A1 RID: 673
		弓手男03,
		// Token: 0x040002A2 RID: 674
		弓手男04,
		// Token: 0x040002A3 RID: 675
		弓手男05,
		// Token: 0x040002A4 RID: 676
		弓手男06,
		// Token: 0x040002A5 RID: 677
		弓手男07,
		// Token: 0x040002A6 RID: 678
		弓手女00 = 197120,
		// Token: 0x040002A7 RID: 679
		弓手女01,
		// Token: 0x040002A8 RID: 680
		弓手女02,
		// Token: 0x040002A9 RID: 681
		弓手女03,
		// Token: 0x040002AA RID: 682
		弓手女04,
		// Token: 0x040002AB RID: 683
		弓手女05,
		// Token: 0x040002AC RID: 684
		弓手女06,
		// Token: 0x040002AD RID: 685
		弓手女07,
		// Token: 0x040002AE RID: 686
		龙枪男00 = 327936,
		// Token: 0x040002AF RID: 687
		龙枪男01,
		// Token: 0x040002B0 RID: 688
		龙枪男02,
		// Token: 0x040002B1 RID: 689
		龙枪男03,
		// Token: 0x040002B2 RID: 690
		龙枪男04,
		// Token: 0x040002B3 RID: 691
		龙枪男05,
		// Token: 0x040002B4 RID: 692
		龙枪男06,
		// Token: 0x040002B5 RID: 693
		龙枪男07,
		// Token: 0x040002B6 RID: 694
		龙枪女00 = 328192,
		// Token: 0x040002B7 RID: 695
		龙枪女01,
		// Token: 0x040002B8 RID: 696
		龙枪女02,
		// Token: 0x040002B9 RID: 697
		龙枪女03,
		// Token: 0x040002BA RID: 698
		龙枪女04,
		// Token: 0x040002BB RID: 699
		龙枪女05,
		// Token: 0x040002BC RID: 700
		龙枪女06,
		// Token: 0x040002BD RID: 701
		龙枪女07
	}
}
