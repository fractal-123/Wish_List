import { Button, Input, } from '@chakra-ui/react';
import { list } from 'postcss';
import {useState} from "react";

export default function CreateWishForm({onCreate}) {
  const[wish, setWish] = useState({link:null},null);

  const onSubmit = (e) => {
    e.preventDefault();
    setWish(null);
    onCreate(wish);
  };
  
  return(
        <form onSubmit={onSubmit} className='w-full flex flex-col gap-3'>
          <h3 className='font-black text-xl text-center '> Создание желания</h3>
          <Input  
            placeholder='Название' 
            value ={wish?.name ?? ""}
            onChange={(e) => setWish({...wish, name: e.target.value})}/>
          <Input 
            placeholder='Описание' 
            value ={wish?.description ?? ""}
            onChange={(e) => setWish({...wish, description: e.target.value})}/>
          <Input 
            placeholder='Цена'
            value ={wish?.price ?? ""}
            onChange={(e) => setWish({...wish, price: e.target.value})}
            />
            <Input 
            placeholder='Ссылка'
            value ={wish?.link ?? ""}
            onChange={(e) => setWish({...wish, link: e.target.value})}
            />
          <Button type="submit" colorScheme='teal'> Создать </Button>
        </form>
    )
}