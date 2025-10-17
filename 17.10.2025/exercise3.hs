findCircleArea = do
    radiusInput <- getLine
    let radius = read radiusInput :: Double
    let area = radius * radius * pi
    
    let output = show area :: String
    putStrLn output