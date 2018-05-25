
class C
{
    public string Provice { set; get; }
    public string District { set; get; }
    public string Amphoe { set; get; }
}

var datas = new List<C> {
    new C { Provice = "A", District = "B", Amphoe = "C" },
    new C { Provice = "B", District = "B", Amphoe = "C" },
    new C { Provice = "D", District = "B", Amphoe = "D" },
    new C { Provice = "C", District = "B", Amphoe = "C" },
};

var rs =
    datas.GroupBy(c => c.Provice,
        (province, provinceGroup) => provinceGroup.GroupBy(x => x.District,
            (district, districtGroup) => (province, district, districtGroup.Select(vvv => (vvv.Amphoe)))));

foreach (var item in rs)
{
    Console.WriteLine($"{item}");
}


