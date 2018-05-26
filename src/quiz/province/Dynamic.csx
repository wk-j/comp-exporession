var data = new List<dynamic> {
 new { Province = "a", District = "c", SubDistrict = "b" },
 new { Province = "a", District = "c", SubDistrict = "d" },
 new { Province = "a", District = "g", SubDistrict = "k" },
 new { Province = "b", District = "g", SubDistrict = "k" },
};

var finalData = data.GroupBy(x => x.Province).Select(x => {
    var district = x.GroupBy(y => y.District).Select(y => {
        return new {
            y.Key,
            Value = y.Select(k => k.SubDistrict).ToList()
        };
    }).ToList();
    return new {
        x.Key,
        Value = district,
    };
}).ToList();

Console.WriteLine("{");
finalData.ForEach(x => {
    Console.WriteLine($"  {x.Key}: {{"); x.Value.ForEach(y => {
        Console.Write($"    {y.Key}: ["); y.Value.ForEach(z => {
            if (y.Value.IndexOf(z) != 0) {
                Console.Write(", ");
            }
            Console.Write($"{z}");
        }); Console.WriteLine($"],");
    }); Console.WriteLine("  },");
});
Console.WriteLine("}");