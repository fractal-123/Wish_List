import axios from "axios"

export const fetchWish = async (filter) => {
    try{
    var response = await axios.get("http://localhost:5152/Wish", {
        params: {
            search: filter?.search,
            sortItem: filter?.sortItem,
            sortOrder: filter?.sortOrder,
        },
    });

    return response.data.wish;
    } catch(e)  {
         console.error(e);
    }

    
};
export const createWish = async (wish) => {
    try{
    var response = await axios.post("http://localhost:5152/Wish", wish);

    return response.status;
    } catch(e)  {
         console.error(e);
    }

    
};