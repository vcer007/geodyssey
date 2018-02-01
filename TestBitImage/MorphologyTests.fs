﻿#light

open System
open NUnit.Framework
open BitImage
open Image

[<TestFixture>]
type MorphologyTests() =

  let imageFromStrings strings =
    FastImage<bool>( strings
      |> BitImage.Utility.stringListToBools
      |> List.rev
      |> BitImage.Utility.array2FromListOfLists )
  
  let testImage1 =  
    imageFromStrings [ "0000000000000000" ;
                       "0000000000000000" ;
                       "0001110000000000" ;
                       "0011111000000000" ;
                       "0011111000011100" ;
                       "0011110000111100" ;
                       "0001100001111100" ;
                       "0000000011111000" ;
                       "0010000111110000" ;
                       "0000001111100000" ;
                       "0000011111000000" ;
                       "0000111110000000" ;
                       "0000111111110000" ;
                       "0000111111110000" ;
                       "0000011111100000" ;
                       "0000000000000000" ]
  
  let thinnedImage1 =
    imageFromStrings [ "0000000000000000" ;
                       "0000000000000000" ;
                       "0000000000000000" ;
                       "0000010000000000" ;
                       "0000100000000100" ;
                       "0001000000001000" ;
                       "0000000000010000" ;
                       "0000000000100000" ;
                       "0010000001000000" ;
                       "0000000010000000" ;
                       "0000000010000000" ;
                       "0000000010000000" ;
                       "0000001111110000" ;
                       "0000010000100000" ;
                       "0000000000100000" ;
                       "0000000000000000" ]
                                          
  let testImage2 =
    imageFromStrings [ "0000000000000000" ;
                       "0000000000000000" ;
                       "0110000000000000" ;
                       "0001000100000000" ;
                       "0111111111000000" ;
                       "0111111111110000" ;
                       "0111111111111000" ;
                       "0111111111111100" ;
                       "0111000001111100" ;
                       "0110000000111100" ;
                       "0110000000011100" ;
                       "0100000000001100" ;
                       "0100000000001100" ;
                       "0100000000000100" ;
                       "0011100000000000" ;
                       "0000000000000000" ]

  let thinnedImage2 =
    imageFromStrings [ "0000000000000000" ;
                       "0000000000000000" ;
                       "0110000000000000" ;
                       "0001000000000000" ;
                       "0001000000000000" ;
                       "0001000000000000" ;
                       "0001111111000000" ;
                       "0010000000100000" ;
                       "0010000000010000" ;
                       "0100000000010000" ;
                       "0100000000001000" ;
                       "0100000000001000" ;
                       "0100000000001000" ;
                       "0100000000000100" ;
                       "0011100000000000" ;
                       "0000000000000000" ]
    
  let testData3 =
    imageFromStrings [ "0000010000000000" ;
                       "0000010000000000" ;
                       "0000100000000000" ;
                       "0000100000000000" ;
                       "0000100000000000" ;
                       "0000111000000000" ;
                       "0000110000000000" ;
                       "0011110000000000" ;
                       "0100010000000000" ;
                       "1000001000000000" ;
                       "1000000100000000" ;
                       "0000000100000000" ;
                       "0000000100000000" ;
                       "0000000010000000" ;
                       "0000000010000000" ;
                       "0000000001000000" ]

  let testData4 =
    imageFromStrings [ "0000000000010000" ;
                       "0001000000010000" ;
                       "0000100001111100" ;
                       "0000010000010000" ;
                       "0000001000010000" ;
                       "0000000111110000" ;
                       "0000000000010000" ;
                       "0000000000010000" ;
                       "0001110000010000" ;
                       "0000011100010000" ;
                       "0000000010100000" ;
                       "0000000001000000" ;
                       "0000000010100000" ;
                       "0000000100010000" ;
                       "0000000000000000" ;
                       "0000000000000000" ]
                                      
  [<Test>]
  member x.Thinning1 () =
    let thinned1 = Morphology.ThinUntilConvergence testImage1
    Assert.AreEqual(thinnedImage1, thinned1)
    
  [<Test>]
  member x.Thinning2 () =
    let thinned2 = Morphology.ThinUntilConvergence testImage2
    Assert.AreEqual(thinnedImage2, thinned2)