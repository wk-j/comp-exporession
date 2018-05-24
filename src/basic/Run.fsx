
type Run() =
    member __.Return a = Some a
    member __.Run(f) =
        printfn "Run ..."
        f()
    member __.Delay(f) = f()
