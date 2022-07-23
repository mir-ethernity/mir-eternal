using System;

namespace GameServer
{
	// Token: 0x0200004E RID: 78
	public enum ObjectHairType
	{
		// Token: 0x040001CE RID: 462
		战士男00 = 256,
		// Token: 0x040001CF RID: 463
		战士男01,
		// Token: 0x040001D0 RID: 464
		战士男02,
		// Token: 0x040001D1 RID: 465
		战士男03,
		// Token: 0x040001D2 RID: 466
		战士男04,
		// Token: 0x040001D3 RID: 467
		战士男05,
		// Token: 0x040001D4 RID: 468
		战士男06,
		// Token: 0x040001D5 RID: 469
		战士男07,
		// Token: 0x040001D6 RID: 470
		战士男08,
		// Token: 0x040001D7 RID: 471
		战士男09,
		// Token: 0x040001D8 RID: 472
		战士男10,
		// Token: 0x040001D9 RID: 473
		战士男11,
		// Token: 0x040001DA RID: 474
		战士女00 = 512,
		// Token: 0x040001DB RID: 475
		战士女01,
		// Token: 0x040001DC RID: 476
		战士女02,
		// Token: 0x040001DD RID: 477
		战士女03,
		// Token: 0x040001DE RID: 478
		战士女04,
		// Token: 0x040001DF RID: 479
		战士女05,
		// Token: 0x040001E0 RID: 480
		战士女06,
		// Token: 0x040001E1 RID: 481
		战士女07,
		// Token: 0x040001E2 RID: 482
		战士女08,
		// Token: 0x040001E3 RID: 483
		战士女09,
		// Token: 0x040001E4 RID: 484
		战士女10,
		// Token: 0x040001E5 RID: 485
		战士女11,
		// Token: 0x040001E6 RID: 486
		法师男00 = 65792,
		// Token: 0x040001E7 RID: 487
		法师男01,
		// Token: 0x040001E8 RID: 488
		法师男02,
		// Token: 0x040001E9 RID: 489
		法师男03,
		// Token: 0x040001EA RID: 490
		法师男04,
		// Token: 0x040001EB RID: 491
		法师男05,
		// Token: 0x040001EC RID: 492
		法师男06,
		// Token: 0x040001ED RID: 493
		法师男07,
		// Token: 0x040001EE RID: 494
		法师男08,
		// Token: 0x040001EF RID: 495
		法师男09,
		// Token: 0x040001F0 RID: 496
		法师男10,
		// Token: 0x040001F1 RID: 497
		法师男11,
		// Token: 0x040001F2 RID: 498
		法师女00 = 66048,
		// Token: 0x040001F3 RID: 499
		法师女01,
		// Token: 0x040001F4 RID: 500
		法师女02,
		// Token: 0x040001F5 RID: 501
		法师女03,
		// Token: 0x040001F6 RID: 502
		法师女04,
		// Token: 0x040001F7 RID: 503
		法师女05,
		// Token: 0x040001F8 RID: 504
		法师女06,
		// Token: 0x040001F9 RID: 505
		法师女07,
		// Token: 0x040001FA RID: 506
		法师女08,
		// Token: 0x040001FB RID: 507
		法师女09,
		// Token: 0x040001FC RID: 508
		法师女10,
		// Token: 0x040001FD RID: 509
		法师女11,
		// Token: 0x040001FE RID: 510
		道士男00 = 262400,
		// Token: 0x040001FF RID: 511
		道士男01,
		// Token: 0x04000200 RID: 512
		道士男02,
		// Token: 0x04000201 RID: 513
		道士男03,
		// Token: 0x04000202 RID: 514
		道士男04,
		// Token: 0x04000203 RID: 515
		道士男05,
		// Token: 0x04000204 RID: 516
		道士男06,
		// Token: 0x04000205 RID: 517
		道士男07,
		// Token: 0x04000206 RID: 518
		道士男08,
		// Token: 0x04000207 RID: 519
		道士男09,
		// Token: 0x04000208 RID: 520
		道士男10,
		// Token: 0x04000209 RID: 521
		道士男11,
		// Token: 0x0400020A RID: 522
		道士女00 = 262656,
		// Token: 0x0400020B RID: 523
		道士女01,
		// Token: 0x0400020C RID: 524
		道士女02,
		// Token: 0x0400020D RID: 525
		道士女03,
		// Token: 0x0400020E RID: 526
		道士女04,
		// Token: 0x0400020F RID: 527
		道士女05,
		// Token: 0x04000210 RID: 528
		道士女06,
		// Token: 0x04000211 RID: 529
		道士女07,
		// Token: 0x04000212 RID: 530
		道士女08,
		// Token: 0x04000213 RID: 531
		道士女09,
		// Token: 0x04000214 RID: 532
		道士女10,
		// Token: 0x04000215 RID: 533
		道士女11,
		// Token: 0x04000216 RID: 534
		刺客男00 = 131328,
		// Token: 0x04000217 RID: 535
		刺客男01,
		// Token: 0x04000218 RID: 536
		刺客男02,
		// Token: 0x04000219 RID: 537
		刺客男03,
		// Token: 0x0400021A RID: 538
		刺客男04,
		// Token: 0x0400021B RID: 539
		刺客男05,
		// Token: 0x0400021C RID: 540
		刺客男06,
		// Token: 0x0400021D RID: 541
		刺客男07,
		// Token: 0x0400021E RID: 542
		刺客男08,
		// Token: 0x0400021F RID: 543
		刺客男09,
		// Token: 0x04000220 RID: 544
		刺客女00 = 131584,
		// Token: 0x04000221 RID: 545
		刺客女01,
		// Token: 0x04000222 RID: 546
		刺客女02,
		// Token: 0x04000223 RID: 547
		刺客女03,
		// Token: 0x04000224 RID: 548
		刺客女04,
		// Token: 0x04000225 RID: 549
		刺客女05,
		// Token: 0x04000226 RID: 550
		刺客女06,
		// Token: 0x04000227 RID: 551
		刺客女07,
		// Token: 0x04000228 RID: 552
		刺客女08,
		// Token: 0x04000229 RID: 553
		刺客女09,
		// Token: 0x0400022A RID: 554
		刺客女10,
		// Token: 0x0400022B RID: 555
		刺客女11,
		// Token: 0x0400022C RID: 556
		弓手男00 = 196864,
		// Token: 0x0400022D RID: 557
		弓手男01,
		// Token: 0x0400022E RID: 558
		弓手男02,
		// Token: 0x0400022F RID: 559
		弓手男03,
		// Token: 0x04000230 RID: 560
		弓手男04,
		// Token: 0x04000231 RID: 561
		弓手男05,
		// Token: 0x04000232 RID: 562
		弓手男06,
		// Token: 0x04000233 RID: 563
		弓手男07,
		// Token: 0x04000234 RID: 564
		弓手男08,
		// Token: 0x04000235 RID: 565
		弓手男09,
		// Token: 0x04000236 RID: 566
		弓手男10,
		// Token: 0x04000237 RID: 567
		弓手男11,
		// Token: 0x04000238 RID: 568
		弓手女00 = 197120,
		// Token: 0x04000239 RID: 569
		弓手女01,
		// Token: 0x0400023A RID: 570
		弓手女02,
		// Token: 0x0400023B RID: 571
		弓手女03,
		// Token: 0x0400023C RID: 572
		弓手女04,
		// Token: 0x0400023D RID: 573
		弓手女05,
		// Token: 0x0400023E RID: 574
		弓手女06,
		// Token: 0x0400023F RID: 575
		弓手女07,
		// Token: 0x04000240 RID: 576
		弓手女08,
		// Token: 0x04000241 RID: 577
		弓手女09,
		// Token: 0x04000242 RID: 578
		弓手女10,
		// Token: 0x04000243 RID: 579
		弓手女11,
		// Token: 0x04000244 RID: 580
		龙枪男00 = 327936,
		// Token: 0x04000245 RID: 581
		龙枪男01,
		// Token: 0x04000246 RID: 582
		龙枪男02,
		// Token: 0x04000247 RID: 583
		龙枪男03,
		// Token: 0x04000248 RID: 584
		龙枪男04,
		// Token: 0x04000249 RID: 585
		龙枪男05,
		// Token: 0x0400024A RID: 586
		龙枪男06,
		// Token: 0x0400024B RID: 587
		龙枪男07,
		// Token: 0x0400024C RID: 588
		龙枪女00 = 328192,
		// Token: 0x0400024D RID: 589
		龙枪女01,
		// Token: 0x0400024E RID: 590
		龙枪女02,
		// Token: 0x0400024F RID: 591
		龙枪女03,
		// Token: 0x04000250 RID: 592
		龙枪女04,
		// Token: 0x04000251 RID: 593
		龙枪女05,
		// Token: 0x04000252 RID: 594
		龙枪女06,
		// Token: 0x04000253 RID: 595
		龙枪女07
	}
}
