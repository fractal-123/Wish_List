import axios from "axios"

axios.defaults.withCredentials = true;
export const fetchWish = async () => {
    try {
      const response = await axios.get("http://localhost:5152/Wish/auth-user-wishes");
  

      if (response.data && Array.isArray(response.data.wishes)) {
        console.log(response.data);
        return response.data.wishes;
      } else {
        console.error("Некорректный формат данных от API:", response.data);
        return []; 
      }
    } catch (e) {
      console.error("Ошибка при выполнении запроса:", e);
      return []; 
    }
  };

export const createWish = async (wish) => {
    try{
    var response = await axios.post("http://localhost:5152/wish", wish);
    
    return response.status;
    } catch(e)  {
         console.error(e);
    }

    
};

export const editWish = async (wishId, editData) => {
    try {
      const response = await axios.put(
        `http://localhost:5152/Wish/update-wish?wishId=${wishId}`, // Замените на ваш URL
        editData,
        {
          headers: {
            'Content-Type': 'application/json',
          },
          withCredentials: true, // Если сессия или куки используются
        }
      );
      return response.data;
    } catch (error) {
      console.error('Error editing wish:', error);
      throw error;
    }
  };
  