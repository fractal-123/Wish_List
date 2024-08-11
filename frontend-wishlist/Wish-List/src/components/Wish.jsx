import { Card, CardBody, CardFooter, CardHeader, Divider, Heading } from '@chakra-ui/react';


export default function Wish(){
    return(
   
    <Card variant={"filled"}>
        <CardHeader >
            <Heading size={'md'}>Желание</Heading>
        </CardHeader>
        <Divider borderColor={"gray"}/>
        <CardBody>Текст желания</CardBody>
        <Divider borderColor={"gray"}/>
        <CardFooter>Дата создания</CardFooter>
    </Card>
            
    
    );
} 