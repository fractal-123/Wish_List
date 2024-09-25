import { Button, Input} from '@chakra-ui/react';
import {useState} from "react";

export default function CreateWishForm({onCreate}) {
  const[wish, setWish] = useState(null);

  const onSubmit = (e) => {
    e.preventDefault();
    setWish(null);
    onCreate(wish);
  };
  
  return(
        <form onSubmit={onSubmit} className='w-full flex flex-col gap-3'>
          <h3 className='font-bold text-xl text-center'> Создание желания</h3>
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
          <Button type="submit" colorScheme='teal'> Создать </Button>
        </form>
    )
}