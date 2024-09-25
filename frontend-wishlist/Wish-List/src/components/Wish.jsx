import { Card, CardBody, CardFooter, CardHeader, Center, Divider, Heading } from '@chakra-ui/react';
import moment from 'moment';

export default function Wish({ created, description, name, price}){
    return(
   
    <Card  boxShadow='dark-lg' boxSize="sm" h="200"  align="right" justify="right" >
        <CardHeader > 
            <Heading size='md' textAlign = 'center'>{name}</Heading>
        </CardHeader>
        <Divider borderColor={"gray"} />
        <CardBody textAlign = 'right' >
            <div > {description}</div>
            <div>{price}</div>
        </CardBody>
        <Divider borderColor={"gray"}/>
        <CardFooter>{moment(created).format("DD.MM.YYYY  h:mm:ss")}</CardFooter>
    </Card>
    );
}   