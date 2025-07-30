using SunamoGpx.Tests;

//SunamoMapyCzServiceTests sunamoMapyCzServiceTests = new();
//await sunamoMapyCzServiceTests.AddressToCoordsSingleTest();

SunamoGpxServiceTests t = new();
await t.GenerateGpxFileTest();

