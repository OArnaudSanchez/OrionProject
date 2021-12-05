import { useState, useRef, useEffect } from 'react';
import axios from 'axios';

export const useFetch = ( endpoint ) => {
    
    const API_URL = `https://localhost:44349/api/${ endpoint }`;
    const isMounted = useRef(true);
    const [ state, setState ] = useState({
        data: null,
        loading: true,
        errors: null
    });

    useEffect( () => {
        return () => { isMounted.current = false };
    }, []);

    useEffect( () => {

        setState({
            data: null,
            loading: true,
            errors: null
        });
        const fetchData = async() => {

            try{
                const { data } = await axios(API_URL);
                if(isMounted.current){
                    setState({
                        data,
                        loading: false,
                        errors: null,
                    });
                }
            }catch(error){
                setState({
                    data: null,
                    loading: false,
                    errors: Array.from(error),
                });
            }
        };

        fetchData();

    } , [ API_URL ]);
    return state;
};