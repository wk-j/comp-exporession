open System

let bind f m =
    match m with
    | Ok data -> f data
    | Error err -> Error err

let parseInt s =
    let ok, rs = Int32.TryParse s
    if ok then Ok rs
    else Error "Invalid input"

let (>>=) m f = bind f m

Ok "100" >>= parseInt
|> printfn "%A"

Error "X" >>= parseInt
|> printfn "%A"

Ok "X" >>= parseInt
|> printfn "%A"


type MyResult() =
    member __.Bind(m, f) = bind f m
    member __.Return(r) = Ok r

let rs = MyResult()

rs {
    let! a11 = ("100" |> parseInt)
    let! a22 = ("200" |> parseInt)
    return a11 + a22
} |> printfn "%A"



