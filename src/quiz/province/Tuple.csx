#! "netcoreapp2.1"
#r "nuget: Newtonsoft.Json,11.0.2"
// [ {:province :a, :district :b, :amphoe :c}, {:province: a, :district: k, :amphoe: g} ]

using Newtonsoft.Json;

class P {
    public string Province { set; get; }
    public string Amphoe { set; get; }
    public string District { set; get; }
}

var data = new dynamic[] {
    new { Province = "A", Amphoe = "C", District = "B"},
    new { Province = "A", Amphoe = "C", District = "C"},
    new { Province = "A", Amphoe = "G", District = "K"}
};

var rs = data.GroupBy(x => x.Province).Select(x =>
    (x.Key, x.GroupBy(k => k.Amphoe).Select(a =>
        (a.Key, a.Select(y => y.District)))
    )
);

var dict = rs.ToDictionary(x => x.Key, x => x.Item2.ToDictionary(k => k.Key, k => k.Item2));

var json = JsonConvert.SerializeObject(dict);
Console.WriteLine(json);

