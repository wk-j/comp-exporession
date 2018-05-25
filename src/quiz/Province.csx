var data = new List<dynamic> {
    new { Province = "a", District = "c", SubDistrict = "b" },
    new { Province = "a", District = "g", SubDistrict = "k" },
    new { Province = "b", District = "g", SubDistrict = "k" },
};

var finalData = data.GroupBy(x => x.Province).Select(x =>
{
    var district = x.GroupBy(y => y.District).Select(y =>
    {
        return new { y.Key, Value = data.Where(z => z.District == y.Key).Select(z => z.SubDistrict).ToList(), };
    }).ToList();
    return new { x.Key, Value = district, };
}).ToList();


foreach (var i1 in finalData)
{
    Console.Write($"Provice = {i1.Key}, ");
    foreach (var i2 in i1.Value)
    {
        Console.Write($"District = {i2.Key}, Sub =");
        foreach (var i3 in i2.Value)
        {
            Console.Write($"{i3}, ");
        }
    }
    Console.WriteLine();
}

