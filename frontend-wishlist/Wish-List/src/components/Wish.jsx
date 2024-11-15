import { Card, CardBody, CardHeader, Center, Divider, Heading, Link } from '@chakra-ui/react';
import moment from 'moment';

export default function Wish({ created, description, name, price, link}){
    return(
   
    <Card boxShadow='dark-lg' boxSize="sm" h="200"  align-text="right" justify="right"  >
        <CardHeader  > 
            <Heading class='text-xl text-center font-bold'>{name}</Heading>
        </CardHeader>
        <Divider borderColor={"gray"} />
        <CardBody textAlign = "right"  gap = "4" className='font-serif'>
            <div >
                <span class="float-left ">Описание</span>
                <div>{description}</div>
            </div>
            <div >
                <span class="float-left ">Ссылка</span>
                <Link>
                <a href={link} class="no-underline hover:underline ... text-blue-700">ссылка</a>
                </Link>
            </div>
            <div>
                <span class="float-left ">Цена</span>
                <span>{price} руб.</span>
            </div>
            <div>
                <span class="float-left ">Дата создания</span>
                <span>{moment(created).format("DD.MM.YYYY  h:mm:ss")}</span>
            </div>
        </CardBody>
        
    </Card>
    );
}   