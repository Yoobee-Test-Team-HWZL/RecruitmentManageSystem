(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-0187f9d4"],{"09fe":function(t,e,i){},4056:function(t,e,i){"use strict";i("68ef"),i("9d70"),i("3743"),i("09fe")},"44bf":function(t,e,i){"use strict";var a=i("2638"),r=i.n(a),s=i("d282"),n=i("a142"),o=i("ea8e"),l=i("ad06"),c=Object(s["a"])("image"),d=c[0],h=c[1];e["a"]=d({props:{src:String,fit:String,alt:String,round:Boolean,width:[Number,String],height:[Number,String],radius:[Number,String],lazyLoad:Boolean,iconPrefix:String,showError:{type:Boolean,default:!0},showLoading:{type:Boolean,default:!0},errorIcon:{type:String,default:"photo-fail"},loadingIcon:{type:String,default:"photo"}},data:function(){return{loading:!0,error:!1}},watch:{src:function(){this.loading=!0,this.error=!1}},computed:{style:function(){var t={};return Object(n["c"])(this.width)&&(t.width=Object(o["a"])(this.width)),Object(n["c"])(this.height)&&(t.height=Object(o["a"])(this.height)),Object(n["c"])(this.radius)&&(t.overflow="hidden",t.borderRadius=Object(o["a"])(this.radius)),t}},created:function(){var t=this.$Lazyload;t&&n["b"]&&(t.$on("loaded",this.onLazyLoaded),t.$on("error",this.onLazyLoadError))},beforeDestroy:function(){var t=this.$Lazyload;t&&(t.$off("loaded",this.onLazyLoaded),t.$off("error",this.onLazyLoadError))},methods:{onLoad:function(t){this.loading=!1,this.$emit("load",t)},onLazyLoaded:function(t){var e=t.el;e===this.$refs.image&&this.loading&&this.onLoad()},onLazyLoadError:function(t){var e=t.el;e!==this.$refs.image||this.error||this.onError()},onError:function(t){this.error=!0,this.loading=!1,this.$emit("error",t)},onClick:function(t){this.$emit("click",t)},genPlaceholder:function(){var t=this.$createElement;return this.loading&&this.showLoading?t("div",{class:h("loading")},[this.slots("loading")||t(l["a"],{attrs:{name:this.loadingIcon,classPrefix:this.iconPrefix},class:h("loading-icon")})]):this.error&&this.showError?t("div",{class:h("error")},[this.slots("error")||t(l["a"],{attrs:{name:this.errorIcon,classPrefix:this.iconPrefix},class:h("error-icon")})]):void 0},genImage:function(){var t=this.$createElement,e={class:h("img"),attrs:{alt:this.alt},style:{objectFit:this.fit}};if(!this.error)return this.lazyLoad?t("img",r()([{ref:"image",directives:[{name:"lazy",value:this.src}]},e])):t("img",r()([{attrs:{src:this.src},on:{load:this.onLoad,error:this.onError}},e]))}},render:function(){var t=arguments[0];return t("div",{class:h({round:this.round}),style:this.style,on:{click:this.onClick}},[this.genImage(),this.genPlaceholder(),this.slots()])}})},"4f39":function(t,e,i){"use strict";function a(t){return t=t.substring(0,19),t=t.replace(/-/g,"/"),new Date(t).getTime()}function r(t,e){if(0===arguments.length)return null;const i=e||"{y}-{m}-{d} {h}:{i}:{s}";let a;"object"===typeof t?a=t:("string"===typeof t&&/^[0-9]+$/.test(t)&&(t=parseInt(t)),"number"===typeof t&&10===t.toString().length&&(t*=1e3),a=new Date(t));const r={y:a.getFullYear(),m:a.getMonth()+1,d:a.getDate(),h:a.getHours(),i:a.getMinutes(),s:a.getSeconds(),a:a.getDay()},s=i.replace(/{(y|m|d|h|i|s|a)+}/g,(t,e)=>{let i=r[e];return"a"===e?["日","一","二","三","四","五","六"][i]:(t.length>0&&i<10&&(i="0"+i),i||0)});return s}i.d(e,"a",(function(){return a})),i.d(e,"b",(function(){return r}))},af78:function(t,e,i){"use strict";i.r(e);var a=function(){var t=this,e=t._self._c;return e("div",{staticClass:"gift-div"},[e("div",{staticClass:"title-pic"},[e("div",{staticClass:"left-view"},[e("van-image",{staticClass:"left-pic",attrs:{fit:"fill",src:t.tableData.employer_icon}}),e("div",{staticClass:"right-title"},[t._v(t._s(t.tableData.employer_name))])],1),e("div",{staticClass:"right-button",on:{click:function(e){return t.Apply(t.tableData)}}},[t._v("Check Candidate")])]),e("div",{staticClass:"des-title"},[t._v("Application Open: "+t._s(t.tableData.start_time))]),e("div",{staticClass:"des-title"},[t._v("Application Close: "+t._s(t.tableData.end_time))]),e("div",{staticClass:"des-title"},[t._v("Position name: "+t._s(t.tableData.position_name))]),e("div",{staticClass:"gift-content"},[e("div",{staticClass:"des-title"},[t._v("Describe: "+t._s(t.tableData.desc))]),e("div",{staticClass:"des-title-big"},[t._v("Salary: "+t._s(t.tableData.salary_range))])])])},r=[],s=(i("4056"),i("44bf")),n=i("4f39"),o={name:"JobList",components:{[s["a"].name]:s["a"]},data(){return{kongge:"",time:0}},filters:{startTimeFilter(t,e){var i=new Date,a=Object(n["b"])(i,"{y}-{m}-{d} {h}:{i}:{s}"),r=Object(n["a"])(a),s=Object(n["a"])(t);let o=s-r;return o},timeFilter(t,e){var i=new Date,a=Object(n["b"])(i,"{y}-{m}-{d} {h}:{i}:{s}"),r=Object(n["a"])(a),s=Object(n["a"])(t);let o=s-r;return o}},props:{tableData:{type:Object,default:()=>{}}},mounted(){},methods:{toDetail(t){},Apply(t){this.$emit("checkCandidate",t)}},watch:{tableData(t){}}},l=o,c=(i("cbb8"),i("2877")),d=Object(c["a"])(l,a,r,!1,null,"7c8d6741",null);e["default"]=d.exports},cbb8:function(t,e,i){"use strict";i("d886")},d886:function(t,e,i){}}]);
//# sourceMappingURL=chunk-0187f9d4.57fc5ad3.js.map