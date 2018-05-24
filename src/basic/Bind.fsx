open System

type B() =
    member __.Bind(mt, f) =
        match mt with
        | Some d -> f d
        | None -> None
    member __.Return(x) = Some x

let b = B()

let parse s = Int32.Parse s

b {
    let! x = Some "1"
    let! y = Some "2"
    let! z = None
    return parse(x + y + z)
}

|> printfn "%A"