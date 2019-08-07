import ajax from '../../lib/ajax';
const account={
    namespaced: true,
    state:{
        
    },
    actions:{
        async isTenantAvailable(state:any,payload:any){
            let rep=await ajax.post('/Account/IsTenantAvailable',payload.data);
            return rep.data.result;
        }
    }
}
export default account;