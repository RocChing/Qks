import Vue from 'vue';
import App from './app.vue';
import iView from 'iview';
import { router } from './router/index';
import 'famfamfam-flags/dist/sprite/famfamfam-flags.css';
import './theme.less';
import ajax from './lib/ajax';
import Util from './lib/util';
import SignalRAspNetCoreHelper from './lib/SignalRAspNetCoreHelper';
import store from './store/index';
import { appRouters, otherRouters } from './router/router';

Vue.use(iView);
Vue.config.productionTip = false;

if (!abp.utils.getCookieValue('Abp.Localization.CultureName')) {
  let language = navigator.language;
  abp.utils.setCookieValue('Abp.Localization.CultureName', language, new Date(new Date().getTime() + 5 * 365 * 86400000), abp.appPath);
}

ajax.get('/AbpUserConfiguration/GetAll', { params: { urlType: 1 } }).then(res => {
  Util.abp = Util.extend(true, Util.abp, res.data.result);
  new Vue({
    render: h => h(App),
    router: router,
    store: store,
    data: {
      currentPageName: ''
    },
    async mounted() {
      this.currentPageName = this.$route.name as string;
      await this.$store.dispatch({
        type: 'session/init'
      })
      if (!!this.$store.state.session.user && this.$store.state.session.application.features['SignalR']) {
        if (this.$store.state.session.application.features['SignalR.AspNetCore']) {
          SignalRAspNetCoreHelper.initSignalR();
        }
      }
      this.$store.commit('app/initCachepage');
      this.$store.commit('app/updateMenulist');
    },
    created() {
      let tagsList: Array<any> = [];
      appRouters.map((item) => {
        if (item.children.length <= 1) {
          tagsList.push(item.children[0]);
        } else {
          tagsList.push(...item.children);
        }
      });
      this.$store.commit('app/setTagsList', tagsList);
    }
  }).$mount('#app')
})

