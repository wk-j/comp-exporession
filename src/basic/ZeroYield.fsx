type TraceBuilder() =
    member __.Zero() =
        printfn "Zero"
        None
    member __.Return (r) = Some r
    member __.Yield(x) = Some x


let trace = TraceBuilder()

trace {
    printfn "Hello, world!"
} |> printfn "%A"

trace {
    if false then return 1
} |> printfn "Result for if without else: %A"

trace {
    yield 1
} |> printfn "Result for yield: %A"