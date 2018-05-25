open System.Linq

type C = {
    Province: string
    Amphoe: string
    District: string
}

type Un() =
    member __.Bind(m, f) =
        ()

let data = [
    { Province = "A";  Amphoe = "A"; District = "A" }
    { Province = "A";  Amphoe = "B"; District = "B" }
    { Province = "B";  Amphoe = "C"; District = "C" }
    { Province = "B";  Amphoe = "D"; District = "D" }
    { Province = "C";  Amphoe = "E"; District = "E" }
    { Province = "C";  Amphoe = "F"; District = "F" }
]

let bind xm f =
    match xm with
    | (_, values) -> f values

type A() =
    member __.Bind(m, f) = bind m f
    member __.Return d = [d]

let a = A()

a {
    let! values = data.GroupBy(fun x -> x.Province)
    return values
}