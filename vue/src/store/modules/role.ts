import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import { Role, FlatPermission } from '../entities/role'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface RoleState extends ListState<Role> {
    editRole: Role;
    permissions: Array<string>;
    allPermissions: Array<FlatPermission>;
}
class RoleModule extends ListModule<RoleState, any, Role>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<Role>(),
        loading: false,
        editRole: new Role(),
        permissions: new Array<string>(),
        allPermissions: new Array<FlatPermission>()
    }
    actions = {
        async getAll(context: ActionContext<RoleState, any>, payload: any) {
            context.state.loading = true;
            let reponse = await Ajax.get('/Role/GetAll', { params: payload.data });
            context.state.loading = false;
            let page = reponse.data.result as PageResult<Role>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
        },
        async create(context: ActionContext<RoleState, any>, payload: any) {
            await Ajax.post('/Role/Create', payload.data);
        },
        async update(context: ActionContext<RoleState, any>, payload: any) {
            context.commit('setPermissions', payload.data)
            await Ajax.put('/Role/Update', payload.data);
        },
        async delete(context: ActionContext<RoleState, any>, payload: any) {
            await Ajax.delete('/Role/Delete?Id=' + payload.data.id);
        },
        async get(context: ActionContext<RoleState, any>, payload: any) {
            let reponse = await Ajax.get('/Role/Get?Id=' + payload.id);
            return reponse.data.result as Role;
        },
        async getAllPermissions(context: ActionContext<RoleState, any>) {
            let reponse = await Ajax.get('/Role/getAllPermissions2');
            context.state.allPermissions.push(...reponse.data.result.items)
            //context.state.permissions = reponse.data.result.items;
        }
    };
    mutations = {
        setCurrentPage(state: RoleState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: RoleState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: RoleState, role: Role) {
            function hasPermission(p: string) {
                let find = false;
                role.grantedPermissions.forEach(item => {
                    if (item === p) {
                        find = true;
                        return false;
                    }
                });
                return find;
            }
            state.allPermissions.forEach(item => {
                if (item.children.length == 0 && hasPermission(item.name)) {
                    item.checked = true;
                }
                item.children.forEach(child => {
                    if (hasPermission(child.name)) {
                        child.checked = true;
                    }
                });
            });
            state.editRole = role;
        },
        setPermissions(state: RoleState, role: Role) {
            let permissions = [];
            state.allPermissions.forEach(item => {
                if (item.children.length == 0 && item.checked) {
                    permissions.push(item.name);
                }
                let pushed = false;
                item.children.forEach(child => {
                    if (child.checked) {
                        if( !pushed){
                            permissions.push(item.name);
                            pushed = true;
                        }
                        permissions.push(child.name)
                    }
                });
            });
            role.grantedPermissions = [...permissions];
        }
    }
}
const roleModule = new RoleModule();
export default roleModule;