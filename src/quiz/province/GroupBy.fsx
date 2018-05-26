open System.Linq

type C = {
    Province: string
    Amphoe: string
    District: string
}

let data = [
    { Province = "PA";  Amphoe = "A"; District = "DA" }
    { Province = "PA";  Amphoe = "A"; District = "DB" }
    { Province = "PB";  Amphoe = "C"; District = "DC" }
    { Province = "PB";  Amphoe = "D"; District = "DD" }
    { Province = "PC";  Amphoe = "E"; District = "DE" }
    { Province = "PC";  Amphoe = "E"; District = "DF" }
]

let y = data |> List.groupBy (fun x -> x.Province)

let x =
    data
    |> List.groupBy (fun x -> x.Province)
    |> List.map (fun (province, provinceGroup) ->
        (province, provinceGroup |> List.groupBy (fun x -> x.Amphoe) |> List.map (
            fun (amphoe, amphoeGroup) -> (amphoe, amphoeGroup |> List.map (fun k -> k.District))
        ))
)

printfn "%A" x
