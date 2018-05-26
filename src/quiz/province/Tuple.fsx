
let data = [
    "A", "C", "B"
    "A", "G", "K"
]

let province (a, _, _) = a
let amphoe (_, a, _) = a
let district (_, _, a) = a

data
|> List.groupBy (province)
|> List.map (fun (key, values) ->
    key,
    values
    |> List.groupBy (amphoe)
    |> List.map (fun (key, values) ->
        key, values |> List.map district
    )
)

|> printfn "%A"