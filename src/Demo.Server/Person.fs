namespace Demo.Server

type Alignment =
    | Evil
    | Neutral
    | Good
    
type Gender =
    | Male
    | Female
    | N of genderName: string
    
type Person =
    { Name: string
      Alignment: Alignment
      GenderTransition: Result<Gender, string> }