jQuery.webshims.register("form-message",function(e,t,n,r,i,s){"use strict";var o=t.validityMessages,u=s.overrideMessages||s.customMessages?["customValidationMessage"]:[];o.en=e.extend(!0,{typeMismatch:{email:"Please enter an email address.",url:"Please enter a URL.",number:"Please enter a number.",date:"Please enter a date.",time:"Please enter a time.",range:"Invalid input.","datetime-local":"Please enter a datetime."},rangeUnderflow:{defaultMessage:"Value must be greater than or equal to {%min}."},rangeOverflow:{defaultMessage:"Value must be less than or equal to {%max}."},stepMismatch:"Invalid input.",tooLong:"Please enter at most {%maxlength} character(s). You entered {%valueLen}.",patternMismatch:"Invalid input. {%title}",valueMissing:{defaultMessage:"Please fill out this field.",checkbox:"Please check this box if you want to proceed."}},o.en||o["en-US"]||{}),["select","radio"].forEach(function(e){typeof o["en"].valueMissing=="object"&&(o.en.valueMissing[e]="Please select an option.")}),["date","time","datetime-local"].forEach(function(e){typeof o["en"].rangeUnderflow=="object"&&(o.en.rangeUnderflow[e]="Value must be at or after {%min}.")}),["date","time","datetime-local"].forEach(function(e){typeof o["en"].rangeOverflow=="object"&&(o.en.rangeOverflow[e]="Value must be at or before {%max}.")}),o["en-US"]=o["en-US"]||o.en,o[""]=o[""]||o["en-US"],o.de=e.extend(!0,{typeMismatch:{email:"{%value} ist keine zul\u00e4ssige E-Mail-Adresse",url:"{%value} ist keine zul\u00e4ssige Webadresse",number:"{%value} ist keine Nummer!",date:"{%value} ist kein Datum",time:"{%value} ist keine Uhrzeit",range:"{%value} ist keine Nummer!","datetime-local":"{%value} ist kein Datum-Uhrzeit Format."},rangeUnderflow:{defaultMessage:"{%value} ist zu niedrig. {%min} ist der unterste Wert, den Sie benutzen k\u00f6nnen."},rangeOverflow:{defaultMessage:"{%value} ist zu hoch. {%max} ist der oberste Wert, den Sie benutzen k\u00f6nnen."},stepMismatch:"Der Wert {%value} ist in diesem Feld nicht zul\u00e4ssig. Hier sind nur bestimmte Werte zul\u00e4ssig. {%title}",tooLong:"Der eingegebene Text ist zu lang! Sie haben {%valueLen} Zeichen eingegeben, dabei sind {%maxlength} das Maximum.",patternMismatch:"{%value} hat f\u00fcr dieses Eingabefeld ein falsches Format! {%title}",valueMissing:{defaultMessage:"Bitte geben Sie einen Wert ein",checkbox:"Bitte aktivieren Sie das K\u00e4stchen"}},o.de||{}),["select","radio"].forEach(function(e){typeof o["de"].valueMissing=="object"&&(o.de.valueMissing[e]="Bitte w\u00e4hlen Sie eine Option aus")}),["date","time","datetime-local"].forEach(function(e){typeof o["de"].rangeUnderflow=="object"&&(o.de.rangeUnderflow[e]="{%value} ist zu fr\u00fch. {%min} ist die fr\u00fcheste Zeit, die Sie benutzen k\u00f6nnen.")}),["date","time","datetime-local"].forEach(function(e){typeof o["de"].rangeOverflow=="object"&&(o.de.rangeOverflow[e]="{%value} ist zu sp\u00e4t. {%max} ist die sp\u00e4teste Zeit, die Sie benutzen k\u00f6nnen.")});var a=o[""];t.createValidationMessage=function(n,r){var i=a[r];return i&&typeof i!="string"&&(i=i[e.prop(n,"type")]||i[(n.nodeName||"").toLowerCase()]||i.defaultMessage),i&&["value","min","max","title","maxlength","label"].forEach(function(s){if(i.indexOf("{%"+s)===-1)return;var o=(s=="label"?e.trim(e('label[for="'+n.id+'"]',n.form).text()).replace(/\*$|:$/,""):e.attr(n,s))||"";r=="patternMismatch"&&s=="title"&&!o&&t.error("no title for patternMismatch provided. Always add a title attribute."),i=i.replace("{%"+s+"}",o),"value"==s&&(i=i.replace("{%valueLen}",o.length))}),i||""},(t.bugs.validationMessage||!Modernizr.formvalidation||t.bugs.bustedValidity)&&u.push("validationMessage"),t.activeLang({langObj:o,module:"form-core",callback:function(e){a=e}}),u.forEach(function(n){t.defineNodeNamesProperty(["fieldset","output","button"],n,{prop:{value:"",writeable:!1}}),["input","select","textarea"].forEach(function(r){var i=t.defineNodeNameProperty(r,n,{prop:{get:function(){var n=this,r="";if(!e.prop(n,"willValidate"))return r;var s=e.prop(n,"validity")||{valid:1};if(s.valid)return r;r=t.getContentValidationMessage(n,s);if(r)return r;if(s.customError&&n.nodeName){r=Modernizr.formvalidation&&!t.bugs.bustedValidity&&i.prop._supget?i.prop._supget.call(n):t.data(n,"customvalidationMessage");if(r)return r}return e.each(s,function(e,i){if(e=="valid"||!i)return;r=t.createValidationMessage(n,e);if(r)return!1}),r||""},writeable:!1}})})})});