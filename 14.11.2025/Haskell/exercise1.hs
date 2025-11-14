main = do 
    a_string <- getLine
    b_string <- getLine
    h_string <- getLine

    let a = read a_string :: Double
    let b = read b_string :: Double
    let h = read h_string :: Double

    let s = (a + b) * h / 2
    let s_output = show s :: String

    putStrLn("a) Liceto na trapeca e " ++ s_output ++ "kv. m.")

    let water_quantity = fromIntegral (round (s * 900.0 * 10.0)) / 10
    let liters = show water_quantity :: String

    putStrLn("b) Basein na plosht " ++ s_output ++ "kv. m se pulni s " ++ liters ++ " litra voda.")