open System.Linq

type C = {
    Province: string
    Amphoe: string
    District: string
}

let data = [
    { Province = "A";  Amphoe = "A"; District = "A" }
    { Province = "A";  Amphoe = "B"; District = "B" }
    { Province = "B";  Amphoe = "C"; District = "C" }
    { Province = "B";  Amphoe = "D"; District = "D" }
    { Province = "C";  Amphoe = "E"; District = "E" }
    { Province = "C";  Amphoe = "F"; District = "F" }
]

type ListWorkflowBuilder() =
    member __.Bind(list, f) =
        list |> List.collect f

    member __.Return(x) =
        [x]

let l = new ListWorkflowBuilder()

l {
    let! a = data.GroupBy(fun x -> x.Province)
    let! b = a.GroupBy(fun x -> x.Amphoe)
    let! c = b.Select(fun x -> x.District)
    return (a, (b, c))
}
