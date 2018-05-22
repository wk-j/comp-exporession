type R() =
    member __.Return a =
        Some a

let r = R()
let rs =
    r {
        return 100
    }

rs |> printfn "%A"