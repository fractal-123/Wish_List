import { Card, CardBody, CardHeader, Divider, Heading, Link, Image } from '@chakra-ui/react';
import moment from 'moment';
import './Wish.css'


export default function Wish({id, created, description, name, price, link, setSelectedWish, setModalActive }) {
    return (
        <Card className='card' boxShadow='dark-lg' boxSize="sm" h="200">
            <CardHeader className="flex justify-between items-center">
                <Heading className='text-xl font-bold flex justify-center'>{name}</Heading>
                <button
                    className="setting-btn"
                    onClick={() => {
                        setSelectedWish({id, name, description, link, price, created }); // Устанавливаем выбранное желание
                        setModalActive(true); // Открываем модальное окно
                    }}
                >
                    <span className="bar bar1"></span>
                    <span className="bar bar2"></span>
                    <span className="bar bar1"></span>
                </button>
            </CardHeader>
            <Divider borderColor={"gray"} />
            <CardBody textAlign="right" gap="4" className='font-serif'>
                <div>
                    <span className="float-left">Описание</span>
                    <div>{description}</div>
                </div>
                <div>
                    <span className="float-left">Ссылка</span>
                    <Link href={link} className="no-underline hover:underline text-blue-700">ссылка</Link>
                </div>
                <div>
                    <span className="float-left">Цена</span>
                    <span>{price} руб.</span>
                </div>
                <div>
                    <span className="float-left">Дата создания</span>
                    <span>{moment(created).format("DD.MM.YYYY  h:mm:ss")}</span>
                </div>
            </CardBody>
        </Card>
    );
}