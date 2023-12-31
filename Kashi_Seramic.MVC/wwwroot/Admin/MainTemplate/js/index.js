/**
 * Barbercrop
 * Barbercrop is a full featured barber shop template
 * Exclusively on https://1.envato.market/barbercrop-html
 *
 * @encoding        UTF-8
 * @version         1.0.0
 * @copyright       (C) 2018 - 2021 Merkulove ( https://merkulov.design/ ). All rights reserved.
 * @license         Envato License https://1.envato.market/KYbje
 * @contributors    Lamber Lilit (winter.rituel@gmail.com)
 * @support         help@merkulov.design
 **/
 (() => {
    var e = {
            764: function(e) {
                e.exports = function() {
                    "use strict";
                    const e = Object.freeze({
                            cancel: "cancel",
                            backdrop: "backdrop",
                            close: "close",
                            esc: "esc",
                            timer: "timer"
                        }),
                        t = "SweetAlert2:",
                        n = e => {
                            const t = [];
                            for (let n = 0; n < e.length; n++) - 1 === t.indexOf(e[n]) && t.push(e[n]);
                            return t
                        },
                        s = e => e.charAt(0).toUpperCase() + e.slice(1),
                        i = e => Array.prototype.slice.call(e),
                        o = e => {
                            console.warn("".concat(t, " ").concat("object" == typeof e ? e.join(" ") : e))
                        },
                        r = e => {
                            console.error("".concat(t, " ").concat(e))
                        },
                        a = [],
                        l = e => {
                            a.includes(e) || (a.push(e), o(e))
                        },
                        c = (e, t) => {
                            l('"'.concat(e, '" is deprecated and will be removed in the next major release. Please use "').concat(t, '" instead.'))
                        },
                        d = e => "function" == typeof e ? e() : e,
                        u = e => e && "function" == typeof e.toPromise,
                        p = e => u(e) ? e.toPromise() : Promise.resolve(e),
                        h = e => e && Promise.resolve(e) === e,
                        m = e => "object" == typeof e && e.jquery,
                        f = e => e instanceof Element || m(e),
                        g = e => {
                            const t = {};
                            return "object" != typeof e[0] || f(e[0]) ? ["title", "html", "icon"].forEach(((n, s) => {
                                const i = e[s];
                                "string" == typeof i || f(i) ? t[n] = i : void 0 !== i && r("Unexpected type of ".concat(n, '! Expected "string" or "Element", got ').concat(typeof i))
                            })) : Object.assign(t, e[0]), t
                        },
                        v = "swal2-",
                        b = e => {
                            const t = {};
                            for (const n in e) t[e[n]] = v + e[n];
                            return t
                        },
                        w = b(["container", "shown", "height-auto", "iosfix", "popup", "modal", "no-backdrop", "no-transition", "toast", "toast-shown", "show", "hide", "close", "title", "html-container", "actions", "confirm", "deny", "cancel", "default-outline", "footer", "icon", "icon-content", "image", "input", "file", "range", "select", "radio", "checkbox", "label", "textarea", "inputerror", "input-label", "validation-message", "progress-steps", "active-progress-step", "progress-step", "progress-step-line", "loader", "loading", "styled", "top", "top-start", "top-end", "top-left", "top-right", "center", "center-start", "center-end", "center-left", "center-right", "bottom", "bottom-start", "bottom-end", "bottom-left", "bottom-right", "grow-row", "grow-column", "grow-fullscreen", "rtl", "timer-progress-bar", "timer-progress-bar-container", "scrollbar-measure", "icon-success", "icon-warning", "icon-info", "icon-question", "icon-error"]),
                        y = b(["success", "warning", "info", "question", "error"]),
                        C = () => document.body.querySelector(".".concat(w.container)),
                        T = e => {
                            const t = C();
                            return t ? t.querySelector(e) : null
                        },
                        S = e => T(".".concat(e)),
                        x = () => S(w.popup),
                        E = () => S(w.icon),
                        k = () => S(w.title),
                        P = () => S(w["html-container"]),
                        O = () => S(w.image),
                        A = () => S(w["progress-steps"]),
                        M = () => S(w["validation-message"]),
                        L = () => T(".".concat(w.actions, " .").concat(w.confirm)),
                        B = () => T(".".concat(w.actions, " .").concat(w.deny)),
                        $ = () => S(w["input-label"]),
                        I = () => T(".".concat(w.loader)),
                        D = () => T(".".concat(w.actions, " .").concat(w.cancel)),
                        j = () => S(w.actions),
                        z = () => S(w.footer),
                        N = () => S(w["timer-progress-bar"]),
                        H = () => S(w.close),
                        _ = '\n  a[href],\n  area[href],\n  input:not([disabled]),\n  select:not([disabled]),\n  textarea:not([disabled]),\n  button:not([disabled]),\n  iframe,\n  object,\n  embed,\n  [tabindex="0"],\n  [contenteditable],\n  audio[controls],\n  video[controls],\n  summary\n',
                        G = () => {
                            const e = i(x().querySelectorAll('[tabindex]:not([tabindex="-1"]):not([tabindex="0"])')).sort(((e, t) => (e = parseInt(e.getAttribute("tabindex"))) > (t = parseInt(t.getAttribute("tabindex"))) ? 1 : e < t ? -1 : 0)),
                                t = i(x().querySelectorAll(_)).filter((e => "-1" !== e.getAttribute("tabindex")));
                            return n(e.concat(t)).filter((e => ae(e)))
                        },
                        V = () => !q() && !document.body.classList.contains(w["no-backdrop"]),
                        q = () => document.body.classList.contains(w["toast-shown"]),
                        F = () => x().hasAttribute("data-loading"),
                        R = {
                            previousBodyPadding: null
                        },
                        W = (e, t) => {
                            if (e.textContent = "", t) {
                                const n = (new DOMParser).parseFromString(t, "text/html");
                                i(n.querySelector("head").childNodes).forEach((t => {
                                    e.appendChild(t)
                                })), i(n.querySelector("body").childNodes).forEach((t => {
                                    e.appendChild(t)
                                }))
                            }
                        },
                        Y = (e, t) => {
                            if (!t) return !1;
                            const n = t.split(/\s+/);
                            for (let t = 0; t < n.length; t++)
                                if (!e.classList.contains(n[t])) return !1;
                            return !0
                        },
                        U = (e, t) => {
                            i(e.classList).forEach((n => {
                                Object.values(w).includes(n) || Object.values(y).includes(n) || Object.values(t.showClass).includes(n) || e.classList.remove(n)
                            }))
                        },
                        X = (e, t, n) => {
                            if (U(e, t), t.customClass && t.customClass[n]) {
                                if ("string" != typeof t.customClass[n] && !t.customClass[n].forEach) return o("Invalid type of customClass.".concat(n, '! Expected string or iterable object, got "').concat(typeof t.customClass[n], '"'));
                                Q(e, t.customClass[n])
                            }
                        },
                        K = (e, t) => {
                            if (!t) return null;
                            switch (t) {
                                case "select":
                                case "textarea":
                                case "file":
                                    return te(e, w[t]);
                                case "checkbox":
                                    return e.querySelector(".".concat(w.checkbox, " input"));
                                case "radio":
                                    return e.querySelector(".".concat(w.radio, " input:checked")) || e.querySelector(".".concat(w.radio, " input:first-child"));
                                case "range":
                                    return e.querySelector(".".concat(w.range, " input"));
                                default:
                                    return te(e, w.input)
                            }
                        },
                        Z = e => {
                            if (e.focus(), "file" !== e.type) {
                                const t = e.value;
                                e.value = "", e.value = t
                            }
                        },
                        J = (e, t, n) => {
                            e && t && ("string" == typeof t && (t = t.split(/\s+/).filter(Boolean)), t.forEach((t => {
                                e.forEach ? e.forEach((e => {
                                    n ? e.classList.add(t) : e.classList.remove(t)
                                })) : n ? e.classList.add(t) : e.classList.remove(t)
                            })))
                        },
                        Q = (e, t) => {
                            J(e, t, !0)
                        },
                        ee = (e, t) => {
                            J(e, t, !1)
                        },
                        te = (e, t) => {
                            for (let n = 0; n < e.childNodes.length; n++)
                                if (Y(e.childNodes[n], t)) return e.childNodes[n]
                        },
                        ne = (e, t, n) => {
                            n === "".concat(parseInt(n)) && (n = parseInt(n)), n || 0 === parseInt(n) ? e.style[t] = "number" == typeof n ? "".concat(n, "px") : n : e.style.removeProperty(t)
                        },
                        se = (e, t = "flex") => {
                            e.style.display = t
                        },
                        ie = e => {
                            e.style.display = "none"
                        },
                        oe = (e, t, n, s) => {
                            const i = e.querySelector(t);
                            i && (i.style[n] = s)
                        },
                        re = (e, t, n) => {
                            t ? se(e, n) : ie(e)
                        },
                        ae = e => !(!e || !(e.offsetWidth || e.offsetHeight || e.getClientRects().length)),
                        le = () => !ae(L()) && !ae(B()) && !ae(D()),
                        ce = e => !!(e.scrollHeight > e.clientHeight),
                        de = e => {
                            const t = window.getComputedStyle(e),
                                n = parseFloat(t.getPropertyValue("animation-duration") || "0"),
                                s = parseFloat(t.getPropertyValue("transition-duration") || "0");
                            return n > 0 || s > 0
                        },
                        ue = (e, t = !1) => {
                            const n = N();
                            ae(n) && (t && (n.style.transition = "none", n.style.width = "100%"), setTimeout((() => {
                                n.style.transition = "width ".concat(e / 1e3, "s linear"), n.style.width = "0%"
                            }), 10))
                        },
                        pe = () => {
                            const e = N(),
                                t = parseInt(window.getComputedStyle(e).width);
                            e.style.removeProperty("transition"), e.style.width = "100%";
                            const n = parseInt(window.getComputedStyle(e).width),
                                s = parseInt(t / n * 100);
                            e.style.removeProperty("transition"), e.style.width = "".concat(s, "%")
                        },
                        he = () => "undefined" == typeof window || "undefined" == typeof document,
                        me = '\n <div aria-labelledby="'.concat(w.title, '" aria-describedby="').concat(w["html-container"], '" class="').concat(w.popup, '" tabindex="-1">\n   <button type="button" class="').concat(w.close, '"></button>\n   <ul class="').concat(w["progress-steps"], '"></ul>\n   <div class="').concat(w.icon, '"></div>\n   <img class="').concat(w.image, '" />\n   <h2 class="').concat(w.title, '" id="').concat(w.title, '"></h2>\n   <div class="').concat(w["html-container"], '" id="').concat(w["html-container"], '"></div>\n   <input class="').concat(w.input, '" />\n   <input type="file" class="').concat(w.file, '" />\n   <div class="').concat(w.range, '">\n     <input type="range" />\n     <output></output>\n   </div>\n   <select class="').concat(w.select, '"></select>\n   <div class="').concat(w.radio, '"></div>\n   <label for="').concat(w.checkbox, '" class="').concat(w.checkbox, '">\n     <input type="checkbox" />\n     <span class="').concat(w.label, '"></span>\n   </label>\n   <textarea class="').concat(w.textarea, '"></textarea>\n   <div class="').concat(w["validation-message"], '" id="').concat(w["validation-message"], '"></div>\n   <div class="').concat(w.actions, '">\n     <div class="').concat(w.loader, '"></div>\n     <button type="button" class="').concat(w.confirm, '"></button>\n     <button type="button" class="').concat(w.deny, '"></button>\n     <button type="button" class="').concat(w.cancel, '"></button>\n   </div>\n   <div class="').concat(w.footer, '"></div>\n   <div class="').concat(w["timer-progress-bar-container"], '">\n     <div class="').concat(w["timer-progress-bar"], '"></div>\n   </div>\n </div>\n').replace(/(^|\n)\s*/g, ""),
                        fe = () => {
                            const e = C();
                            return !!e && (e.remove(), ee([document.documentElement, document.body], [w["no-backdrop"], w["toast-shown"], w["has-column"]]), !0)
                        },
                        ge = () => {
                            Gs.isVisible() && Gs.resetValidationMessage()
                        },
                        ve = () => {
                            const e = x(),
                                t = te(e, w.input),
                                n = te(e, w.file),
                                s = e.querySelector(".".concat(w.range, " input")),
                                i = e.querySelector(".".concat(w.range, " output")),
                                o = te(e, w.select),
                                r = e.querySelector(".".concat(w.checkbox, " input")),
                                a = te(e, w.textarea);
                            t.oninput = ge, n.onchange = ge, o.onchange = ge, r.onchange = ge, a.oninput = ge, s.oninput = () => {
                                ge(), i.value = s.value
                            }, s.onchange = () => {
                                ge(), s.nextSibling.value = s.value
                            }
                        },
                        be = e => "string" == typeof e ? document.querySelector(e) : e,
                        we = e => {
                            const t = x();
                            t.setAttribute("role", e.toast ? "alert" : "dialog"), t.setAttribute("aria-live", e.toast ? "polite" : "assertive"), e.toast || t.setAttribute("aria-modal", "true")
                        },
                        ye = e => {
                            "rtl" === window.getComputedStyle(e).direction && Q(C(), w.rtl)
                        },
                        Ce = e => {
                            const t = fe();
                            if (he()) return void r("SweetAlert2 requires document to initialize");
                            const n = document.createElement("div");
                            n.className = w.container, t && Q(n, w["no-transition"]), W(n, me);
                            const s = be(e.target);
                            s.appendChild(n), we(e), ye(s), ve()
                        },
                        Te = (e, t) => {
                            e instanceof HTMLElement ? t.appendChild(e) : "object" == typeof e ? Se(e, t) : e && W(t, e)
                        },
                        Se = (e, t) => {
                            e.jquery ? xe(t, e) : W(t, e.toString())
                        },
                        xe = (e, t) => {
                            if (e.textContent = "", 0 in t)
                                for (let n = 0; n in t; n++) e.appendChild(t[n].cloneNode(!0));
                            else e.appendChild(t.cloneNode(!0))
                        },
                        Ee = (() => {
                            if (he()) return !1;
                            const e = document.createElement("div"),
                                t = {
                                    WebkitAnimation: "webkitAnimationEnd",
                                    OAnimation: "oAnimationEnd oanimationend",
                                    animation: "animationend"
                                };
                            for (const n in t)
                                if (Object.prototype.hasOwnProperty.call(t, n) && void 0 !== e.style[n]) return t[n];
                            return !1
                        })(),
                        ke = () => {
                            const e = document.createElement("div");
                            e.className = w["scrollbar-measure"], document.body.appendChild(e);
                            const t = e.getBoundingClientRect().width - e.clientWidth;
                            return document.body.removeChild(e), t
                        },
                        Pe = (e, t) => {
                            const n = j(),
                                s = I(),
                                i = L(),
                                o = B(),
                                r = D();
                            t.showConfirmButton || t.showDenyButton || t.showCancelButton ? se(n) : ie(n), X(n, t, "actions"), Ae(i, "confirm", t), Ae(o, "deny", t), Ae(r, "cancel", t), Oe(i, o, r, t), t.reverseButtons && (n.insertBefore(r, s), n.insertBefore(o, s), n.insertBefore(i, s)), W(s, t.loaderHtml), X(s, t, "loader")
                        };

                    function Oe(e, t, n, s) {
                        if (!s.buttonsStyling) return ee([e, t, n], w.styled);
                        Q([e, t, n], w.styled), s.confirmButtonColor && (e.style.backgroundColor = s.confirmButtonColor, Q(e, w["default-outline"])), s.denyButtonColor && (t.style.backgroundColor = s.denyButtonColor, Q(t, w["default-outline"])), s.cancelButtonColor && (n.style.backgroundColor = s.cancelButtonColor, Q(n, w["default-outline"]))
                    }

                    function Ae(e, t, n) {
                        re(e, n["show".concat(s(t), "Button")], "inline-block"), W(e, n["".concat(t, "ButtonText")]), e.setAttribute("aria-label", n["".concat(t, "ButtonAriaLabel")]), e.className = w[t], X(e, n, "".concat(t, "Button")), Q(e, n["".concat(t, "ButtonClass")])
                    }

                    function Me(e, t) {
                        "string" == typeof t ? e.style.background = t : t || Q([document.documentElement, document.body], w["no-backdrop"])
                    }

                    function Le(e, t) {
                        t in w ? Q(e, w[t]) : (o('The "position" parameter is not valid, defaulting to "center"'), Q(e, w.center))
                    }

                    function Be(e, t) {
                        if (t && "string" == typeof t) {
                            const n = "grow-".concat(t);
                            n in w && Q(e, w[n])
                        }
                    }
                    const $e = (e, t) => {
                        const n = C();
                        n && (Me(n, t.backdrop), Le(n, t.position), Be(n, t.grow), X(n, t, "container"))
                    };
                    var Ie = {
                        awaitingPromise: new WeakMap,
                        promise: new WeakMap,
                        innerParams: new WeakMap,
                        domCache: new WeakMap
                    };
                    const De = ["input", "file", "range", "select", "radio", "checkbox", "textarea"],
                        je = (e, t) => {
                            const n = x(),
                                s = Ie.innerParams.get(e),
                                i = !s || t.input !== s.input;
                            De.forEach((e => {
                                const s = w[e],
                                    o = te(n, s);
                                He(e, t.inputAttributes), o.className = s, i && ie(o)
                            })), t.input && (i && ze(t), _e(t))
                        },
                        ze = e => {
                            if (!Fe[e.input]) return r('Unexpected type of input! Expected "text", "email", "password", "number", "tel", "select", "radio", "checkbox", "textarea", "file" or "url", got "'.concat(e.input, '"'));
                            const t = qe(e.input),
                                n = Fe[e.input](t, e);
                            se(n), setTimeout((() => {
                                Z(n)
                            }))
                        },
                        Ne = e => {
                            for (let t = 0; t < e.attributes.length; t++) {
                                const n = e.attributes[t].name;
                                ["type", "value", "style"].includes(n) || e.removeAttribute(n)
                            }
                        },
                        He = (e, t) => {
                            const n = K(x(), e);
                            if (n) {
                                Ne(n);
                                for (const e in t) n.setAttribute(e, t[e])
                            }
                        },
                        _e = e => {
                            const t = qe(e.input);
                            e.customClass && Q(t, e.customClass.input)
                        },
                        Ge = (e, t) => {
                            e.placeholder && !t.inputPlaceholder || (e.placeholder = t.inputPlaceholder)
                        },
                        Ve = (e, t, n) => {
                            if (n.inputLabel) {
                                e.id = w.input;
                                const s = document.createElement("label"),
                                    i = w["input-label"];
                                s.setAttribute("for", e.id), s.className = i, Q(s, n.customClass.inputLabel), s.innerText = n.inputLabel, t.insertAdjacentElement("beforebegin", s)
                            }
                        },
                        qe = e => {
                            const t = w[e] ? w[e] : w.input;
                            return te(x(), t)
                        },
                        Fe = {};
                    Fe.text = Fe.email = Fe.password = Fe.number = Fe.tel = Fe.url = (e, t) => ("string" == typeof t.inputValue || "number" == typeof t.inputValue ? e.value = t.inputValue : h(t.inputValue) || o('Unexpected type of inputValue! Expected "string", "number" or "Promise", got "'.concat(typeof t.inputValue, '"')), Ve(e, e, t), Ge(e, t), e.type = t.input, e), Fe.file = (e, t) => (Ve(e, e, t), Ge(e, t), e), Fe.range = (e, t) => {
                        const n = e.querySelector("input"),
                            s = e.querySelector("output");
                        return n.value = t.inputValue, n.type = t.input, s.value = t.inputValue, Ve(n, e, t), e
                    }, Fe.select = (e, t) => {
                        if (e.textContent = "", t.inputPlaceholder) {
                            const n = document.createElement("option");
                            W(n, t.inputPlaceholder), n.value = "", n.disabled = !0, n.selected = !0, e.appendChild(n)
                        }
                        return Ve(e, e, t), e
                    }, Fe.radio = e => (e.textContent = "", e), Fe.checkbox = (e, t) => {
                        const n = K(x(), "checkbox");
                        n.value = 1, n.id = w.checkbox, n.checked = Boolean(t.inputValue);
                        const s = e.querySelector("span");
                        return W(s, t.inputPlaceholder), e
                    }, Fe.textarea = (e, t) => {
                        e.value = t.inputValue, Ge(e, t), Ve(e, e, t);
                        const n = e => parseInt(window.getComputedStyle(e).marginLeft) + parseInt(window.getComputedStyle(e).marginRight);
                        return setTimeout((() => {
                            if ("MutationObserver" in window) {
                                const t = parseInt(window.getComputedStyle(x()).width);
                                new MutationObserver((() => {
                                    const s = e.offsetWidth + n(e);
                                    x().style.width = s > t ? "".concat(s, "px") : null
                                })).observe(e, {
                                    attributes: !0,
                                    attributeFilter: ["style"]
                                })
                            }
                        })), e
                    };
                    const Re = (e, t) => {
                            const n = P();
                            X(n, t, "htmlContainer"), t.html ? (Te(t.html, n), se(n, "block")) : t.text ? (n.textContent = t.text, se(n, "block")) : ie(n), je(e, t)
                        },
                        We = (e, t) => {
                            const n = z();
                            re(n, t.footer), t.footer && Te(t.footer, n), X(n, t, "footer")
                        },
                        Ye = (e, t) => {
                            const n = H();
                            W(n, t.closeButtonHtml), X(n, t, "closeButton"), re(n, t.showCloseButton), n.setAttribute("aria-label", t.closeButtonAriaLabel)
                        },
                        Ue = (e, t) => {
                            const n = Ie.innerParams.get(e),
                                s = E();
                            return n && t.icon === n.icon ? (Ze(s, t), void Xe(s, t)) : t.icon || t.iconHtml ? t.icon && -1 === Object.keys(y).indexOf(t.icon) ? (r('Unknown icon! Expected "success", "error", "warning", "info" or "question", got "'.concat(t.icon, '"')), ie(s)) : (se(s), Ze(s, t), Xe(s, t), void Q(s, t.showClass.icon)) : ie(s)
                        },
                        Xe = (e, t) => {
                            for (const n in y) t.icon !== n && ee(e, y[n]);
                            Q(e, y[t.icon]), Je(e, t), Ke(), X(e, t, "icon")
                        },
                        Ke = () => {
                            const e = x(),
                                t = window.getComputedStyle(e).getPropertyValue("background-color"),
                                n = e.querySelectorAll("[class^=swal2-success-circular-line], .swal2-success-fix");
                            for (let e = 0; e < n.length; e++) n[e].style.backgroundColor = t
                        },
                        Ze = (e, t) => {
                            e.textContent = "", t.iconHtml ? W(e, Qe(t.iconHtml)) : "success" === t.icon ? W(e, '\n      <div class="swal2-success-circular-line-left"></div>\n      <span class="swal2-success-line-tip"></span> <span class="swal2-success-line-long"></span>\n      <div class="swal2-success-ring"></div> <div class="swal2-success-fix"></div>\n      <div class="swal2-success-circular-line-right"></div>\n    ') : "error" === t.icon ? W(e, '\n      <span class="swal2-x-mark">\n        <span class="swal2-x-mark-line-left"></span>\n        <span class="swal2-x-mark-line-right"></span>\n      </span>\n    ') : W(e, Qe({
                                question: "?",
                                warning: "!",
                                info: "i"
                            }[t.icon]))
                        },
                        Je = (e, t) => {
                            if (t.iconColor) {
                                e.style.color = t.iconColor, e.style.borderColor = t.iconColor;
                                for (const n of [".swal2-success-line-tip", ".swal2-success-line-long", ".swal2-x-mark-line-left", ".swal2-x-mark-line-right"]) oe(e, n, "backgroundColor", t.iconColor);
                                oe(e, ".swal2-success-ring", "borderColor", t.iconColor)
                            }
                        },
                        Qe = e => '<div class="'.concat(w["icon-content"], '">').concat(e, "</div>"),
                        et = (e, t) => {
                            const n = O();
                            if (!t.imageUrl) return ie(n);
                            se(n, ""), n.setAttribute("src", t.imageUrl), n.setAttribute("alt", t.imageAlt), ne(n, "width", t.imageWidth), ne(n, "height", t.imageHeight), n.className = w.image, X(n, t, "image")
                        },
                        tt = e => {
                            const t = document.createElement("li");
                            return Q(t, w["progress-step"]), W(t, e), t
                        },
                        nt = e => {
                            const t = document.createElement("li");
                            return Q(t, w["progress-step-line"]), e.progressStepsDistance && (t.style.width = e.progressStepsDistance), t
                        },
                        st = (e, t) => {
                            const n = A();
                            if (!t.progressSteps || 0 === t.progressSteps.length) return ie(n);
                            se(n), n.textContent = "", t.currentProgressStep >= t.progressSteps.length && o("Invalid currentProgressStep parameter, it should be less than progressSteps.length (currentProgressStep like JS arrays starts from 0)"), t.progressSteps.forEach(((e, s) => {
                                const i = tt(e);
                                if (n.appendChild(i), s === t.currentProgressStep && Q(i, w["active-progress-step"]), s !== t.progressSteps.length - 1) {
                                    const e = nt(t);
                                    n.appendChild(e)
                                }
                            }))
                        },
                        it = (e, t) => {
                            const n = k();
                            re(n, t.title || t.titleText, "block"), t.title && Te(t.title, n), t.titleText && (n.innerText = t.titleText), X(n, t, "title")
                        },
                        ot = (e, t) => {
                            const n = C(),
                                s = x();
                            t.toast ? (ne(n, "width", t.width), s.style.width = "100%", s.insertBefore(I(), E())) : ne(s, "width", t.width), ne(s, "padding", t.padding), t.background && (s.style.background = t.background), ie(M()), rt(s, t)
                        },
                        rt = (e, t) => {
                            e.className = "".concat(w.popup, " ").concat(ae(e) ? t.showClass.popup : ""), t.toast ? (Q([document.documentElement, document.body], w["toast-shown"]), Q(e, w.toast)) : Q(e, w.modal), X(e, t, "popup"), "string" == typeof t.customClass && Q(e, t.customClass), t.icon && Q(e, w["icon-".concat(t.icon)])
                        },
                        at = (e, t) => {
                            ot(e, t), $e(e, t), st(e, t), Ue(e, t), et(e, t), it(e, t), Ye(e, t), Re(e, t), Pe(e, t), We(e, t), "function" == typeof t.didRender && t.didRender(x())
                        },
                        lt = () => ae(x()),
                        ct = () => L() && L().click(),
                        dt = () => B() && B().click(),
                        ut = () => D() && D().click();

                    function pt(...e) {
                        return new this(...e)
                    }

                    function ht(e) {
                        class t extends(this) {
                            _main(t, n) {
                                return super._main(t, Object.assign({}, e, n))
                            }
                        }
                        return t
                    }
                    const mt = e => {
                            let t = x();
                            t || Gs.fire(), t = x();
                            const n = I();
                            q() ? ie(E()) : ft(t, e), se(n), t.setAttribute("data-loading", !0), t.setAttribute("aria-busy", !0), t.focus()
                        },
                        ft = (e, t) => {
                            const n = j(),
                                s = I();
                            !t && ae(L()) && (t = L()), se(n), t && (ie(t), s.setAttribute("data-button-to-replace", t.className)), s.parentNode.insertBefore(s, t), Q([e, n], w.loading)
                        },
                        gt = 100,
                        vt = {},
                        bt = () => {
                            vt.previousActiveElement && vt.previousActiveElement.focus ? (vt.previousActiveElement.focus(), vt.previousActiveElement = null) : document.body && document.body.focus()
                        },
                        wt = e => new Promise((t => {
                            if (!e) return t();
                            const n = window.scrollX,
                                s = window.scrollY;
                            vt.restoreFocusTimeout = setTimeout((() => {
                                bt(), t()
                            }), gt), window.scrollTo(n, s)
                        })),
                        yt = () => vt.timeout && vt.timeout.getTimerLeft(),
                        Ct = () => {
                            if (vt.timeout) return pe(), vt.timeout.stop()
                        },
                        Tt = () => {
                            if (vt.timeout) {
                                const e = vt.timeout.start();
                                return ue(e), e
                            }
                        },
                        St = () => {
                            const e = vt.timeout;
                            return e && (e.running ? Ct() : Tt())
                        },
                        xt = e => {
                            if (vt.timeout) {
                                const t = vt.timeout.increase(e);
                                return ue(t, !0), t
                            }
                        },
                        Et = () => vt.timeout && vt.timeout.isRunning();
                    let kt = !1;
                    const Pt = {};

                    function Ot(e = "data-swal-template") {
                        Pt[e] = this, kt || (document.body.addEventListener("click", At), kt = !0)
                    }
                    const At = e => {
                            for (let t = e.target; t && t !== document; t = t.parentNode)
                                for (const e in Pt) {
                                    const n = t.getAttribute(e);
                                    if (n) return void Pt[e].fire({
                                        template: n
                                    })
                                }
                        },
                        Mt = {
                            title: "",
                            titleText: "",
                            text: "",
                            html: "",
                            footer: "",
                            icon: void 0,
                            iconColor: void 0,
                            iconHtml: void 0,
                            template: void 0,
                            toast: !1,
                            showClass: {
                                popup: "swal2-show",
                                backdrop: "swal2-backdrop-show",
                                icon: "swal2-icon-show"
                            },
                            hideClass: {
                                popup: "swal2-hide",
                                backdrop: "swal2-backdrop-hide",
                                icon: "swal2-icon-hide"
                            },
                            customClass: {},
                            target: "body",
                            backdrop: !0,
                            heightAuto: !0,
                            allowOutsideClick: !0,
                            allowEscapeKey: !0,
                            allowEnterKey: !0,
                            stopKeydownPropagation: !0,
                            keydownListenerCapture: !1,
                            showConfirmButton: !0,
                            showDenyButton: !1,
                            showCancelButton: !1,
                            preConfirm: void 0,
                            preDeny: void 0,
                            confirmButtonText: "OK",
                            confirmButtonAriaLabel: "",
                            confirmButtonColor: void 0,
                            denyButtonText: "No",
                            denyButtonAriaLabel: "",
                            denyButtonColor: void 0,
                            cancelButtonText: "Cancel",
                            cancelButtonAriaLabel: "",
                            cancelButtonColor: void 0,
                            buttonsStyling: !0,
                            reverseButtons: !1,
                            focusConfirm: !0,
                            focusDeny: !1,
                            focusCancel: !1,
                            returnFocus: !0,
                            showCloseButton: !1,
                            closeButtonHtml: "&times;",
                            closeButtonAriaLabel: "Close this dialog",
                            loaderHtml: "",
                            showLoaderOnConfirm: !1,
                            showLoaderOnDeny: !1,
                            imageUrl: void 0,
                            imageWidth: void 0,
                            imageHeight: void 0,
                            imageAlt: "",
                            timer: void 0,
                            timerProgressBar: !1,
                            width: void 0,
                            padding: void 0,
                            background: void 0,
                            input: void 0,
                            inputPlaceholder: "",
                            inputLabel: "",
                            inputValue: "",
                            inputOptions: {},
                            inputAutoTrim: !0,
                            inputAttributes: {},
                            inputValidator: void 0,
                            returnInputValueOnDeny: !1,
                            validationMessage: void 0,
                            grow: !1,
                            position: "center",
                            progressSteps: [],
                            currentProgressStep: void 0,
                            progressStepsDistance: void 0,
                            willOpen: void 0,
                            didOpen: void 0,
                            didRender: void 0,
                            willClose: void 0,
                            didClose: void 0,
                            didDestroy: void 0,
                            scrollbarPadding: !0
                        },
                        Lt = ["allowEscapeKey", "allowOutsideClick", "background", "buttonsStyling", "cancelButtonAriaLabel", "cancelButtonColor", "cancelButtonText", "closeButtonAriaLabel", "closeButtonHtml", "confirmButtonAriaLabel", "confirmButtonColor", "confirmButtonText", "currentProgressStep", "customClass", "denyButtonAriaLabel", "denyButtonColor", "denyButtonText", "didClose", "didDestroy", "footer", "hideClass", "html", "icon", "iconColor", "iconHtml", "imageAlt", "imageHeight", "imageUrl", "imageWidth", "preConfirm", "preDeny", "progressSteps", "returnFocus", "reverseButtons", "showCancelButton", "showCloseButton", "showConfirmButton", "showDenyButton", "text", "title", "titleText", "willClose"],
                        Bt = {},
                        $t = ["allowOutsideClick", "allowEnterKey", "backdrop", "focusConfirm", "focusDeny", "focusCancel", "returnFocus", "heightAuto", "keydownListenerCapture"],
                        It = e => Object.prototype.hasOwnProperty.call(Mt, e),
                        Dt = e => -1 !== Lt.indexOf(e),
                        jt = e => Bt[e],
                        zt = e => {
                            It(e) || o('Unknown parameter "'.concat(e, '"'))
                        },
                        Nt = e => {
                            $t.includes(e) && o('The parameter "'.concat(e, '" is incompatible with toasts'))
                        },
                        Ht = e => {
                            jt(e) && c(e, jt(e))
                        },
                        _t = e => {
                            !e.backdrop && e.allowOutsideClick && o('"allowOutsideClick" parameter requires `backdrop` parameter to be set to `true`');
                            for (const t in e) zt(t), e.toast && Nt(t), Ht(t)
                        };
                    var Gt = Object.freeze({
                        isValidParameter: It,
                        isUpdatableParameter: Dt,
                        isDeprecatedParameter: jt,
                        argsToParams: g,
                        isVisible: lt,
                        clickConfirm: ct,
                        clickDeny: dt,
                        clickCancel: ut,
                        getContainer: C,
                        getPopup: x,
                        getTitle: k,
                        getHtmlContainer: P,
                        getImage: O,
                        getIcon: E,
                        getInputLabel: $,
                        getCloseButton: H,
                        getActions: j,
                        getConfirmButton: L,
                        getDenyButton: B,
                        getCancelButton: D,
                        getLoader: I,
                        getFooter: z,
                        getTimerProgressBar: N,
                        getFocusableElements: G,
                        getValidationMessage: M,
                        isLoading: F,
                        fire: pt,
                        mixin: ht,
                        showLoading: mt,
                        enableLoading: mt,
                        getTimerLeft: yt,
                        stopTimer: Ct,
                        resumeTimer: Tt,
                        toggleTimer: St,
                        increaseTimer: xt,
                        isTimerRunning: Et,
                        bindClickHandler: Ot
                    });

                    function Vt() {
                        const e = Ie.innerParams.get(this);
                        if (!e) return;
                        const t = Ie.domCache.get(this);
                        ie(t.loader), q() ? e.icon && se(E()) : qt(t), ee([t.popup, t.actions], w.loading), t.popup.removeAttribute("aria-busy"), t.popup.removeAttribute("data-loading"), t.confirmButton.disabled = !1, t.denyButton.disabled = !1, t.cancelButton.disabled = !1
                    }
                    const qt = e => {
                        const t = e.popup.getElementsByClassName(e.loader.getAttribute("data-button-to-replace"));
                        t.length ? se(t[0], "inline-block") : le() && ie(e.actions)
                    };

                    function Ft(e) {
                        const t = Ie.innerParams.get(e || this),
                            n = Ie.domCache.get(e || this);
                        return n ? K(n.popup, t.input) : null
                    }
                    const Rt = () => {
                            null === R.previousBodyPadding && document.body.scrollHeight > window.innerHeight && (R.previousBodyPadding = parseInt(window.getComputedStyle(document.body).getPropertyValue("padding-right")), document.body.style.paddingRight = "".concat(R.previousBodyPadding + ke(), "px"))
                        },
                        Wt = () => {
                            null !== R.previousBodyPadding && (document.body.style.paddingRight = "".concat(R.previousBodyPadding, "px"), R.previousBodyPadding = null)
                        },
                        Yt = () => {
                            if ((/iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream || "MacIntel" === navigator.platform && navigator.maxTouchPoints > 1) && !Y(document.body, w.iosfix)) {
                                const e = document.body.scrollTop;
                                document.body.style.top = "".concat(-1 * e, "px"), Q(document.body, w.iosfix), Xt(), Ut()
                            }
                        },
                        Ut = () => {
                            if (!navigator.userAgent.match(/(CriOS|FxiOS|EdgiOS|YaBrowser|UCBrowser)/i)) {
                                const e = 44;
                                x().scrollHeight > window.innerHeight - e && (C().style.paddingBottom = "".concat(e, "px"))
                            }
                        },
                        Xt = () => {
                            const e = C();
                            let t;
                            e.ontouchstart = e => {
                                t = Kt(e)
                            }, e.ontouchmove = e => {
                                t && (e.preventDefault(), e.stopPropagation())
                            }
                        },
                        Kt = e => {
                            const t = e.target,
                                n = C();
                            return !(Zt(e) || Jt(e) || t !== n && (ce(n) || "INPUT" === t.tagName || "TEXTAREA" === t.tagName || ce(P()) && P().contains(t)))
                        },
                        Zt = e => e.touches && e.touches.length && "stylus" === e.touches[0].touchType,
                        Jt = e => e.touches && e.touches.length > 1,
                        Qt = () => {
                            if (Y(document.body, w.iosfix)) {
                                const e = parseInt(document.body.style.top, 10);
                                ee(document.body, w.iosfix), document.body.style.top = "", document.body.scrollTop = -1 * e
                            }
                        },
                        en = () => {
                            i(document.body.children).forEach((e => {
                                e === C() || e.contains(C()) || (e.hasAttribute("aria-hidden") && e.setAttribute("data-previous-aria-hidden", e.getAttribute("aria-hidden")), e.setAttribute("aria-hidden", "true"))
                            }))
                        },
                        tn = () => {
                            i(document.body.children).forEach((e => {
                                e.hasAttribute("data-previous-aria-hidden") ? (e.setAttribute("aria-hidden", e.getAttribute("data-previous-aria-hidden")), e.removeAttribute("data-previous-aria-hidden")) : e.removeAttribute("aria-hidden")
                            }))
                        };
                    var nn = {
                        swalPromiseResolve: new WeakMap,
                        swalPromiseReject: new WeakMap
                    };

                    function sn(e, t, n, s) {
                        q() ? mn(e, s) : (wt(n).then((() => mn(e, s))), vt.keydownTarget.removeEventListener("keydown", vt.keydownHandler, {
                            capture: vt.keydownListenerCapture
                        }), vt.keydownHandlerAdded = !1), /^((?!chrome|android).)*safari/i.test(navigator.userAgent) ? (t.setAttribute("style", "display:none !important"), t.removeAttribute("class"), t.innerHTML = "") : t.remove(), V() && (Wt(), Qt(), tn()), on()
                    }

                    function on() {
                        ee([document.documentElement, document.body], [w.shown, w["height-auto"], w["no-backdrop"], w["toast-shown"]])
                    }

                    function rn(e) {
                        e = un(e);
                        const t = nn.swalPromiseResolve.get(this),
                            n = ln(this);
                        this.isAwaitingPromise() ? e.isDismissed || (dn(this), t(e)) : n && t(e)
                    }

                    function an() {
                        return !!Ie.awaitingPromise.get(this)
                    }
                    const ln = e => {
                        const t = x();
                        if (!t) return !1;
                        const n = Ie.innerParams.get(e);
                        if (!n || Y(t, n.hideClass.popup)) return !1;
                        ee(t, n.showClass.popup), Q(t, n.hideClass.popup);
                        const s = C();
                        return ee(s, n.showClass.backdrop), Q(s, n.hideClass.backdrop), pn(e, t, n), !0
                    };

                    function cn(e) {
                        const t = nn.swalPromiseReject.get(this);
                        dn(this), t && t(e)
                    }
                    const dn = e => {
                            e.isAwaitingPromise() && (Ie.awaitingPromise.delete(e), Ie.innerParams.get(e) || e._destroy())
                        },
                        un = e => void 0 === e ? {
                            isConfirmed: !1,
                            isDenied: !1,
                            isDismissed: !0
                        } : Object.assign({
                            isConfirmed: !1,
                            isDenied: !1,
                            isDismissed: !1
                        }, e),
                        pn = (e, t, n) => {
                            const s = C(),
                                i = Ee && de(t);
                            "function" == typeof n.willClose && n.willClose(t), i ? hn(e, t, s, n.returnFocus, n.didClose) : sn(e, s, n.returnFocus, n.didClose)
                        },
                        hn = (e, t, n, s, i) => {
                            vt.swalCloseEventFinishedCallback = sn.bind(null, e, n, s, i), t.addEventListener(Ee, (function(e) {
                                e.target === t && (vt.swalCloseEventFinishedCallback(), delete vt.swalCloseEventFinishedCallback)
                            }))
                        },
                        mn = (e, t) => {
                            setTimeout((() => {
                                "function" == typeof t && t.bind(e.params)(), e._destroy()
                            }))
                        };

                    function fn(e, t, n) {
                        const s = Ie.domCache.get(e);
                        t.forEach((e => {
                            s[e].disabled = n
                        }))
                    }

                    function gn(e, t) {
                        if (!e) return !1;
                        if ("radio" === e.type) {
                            const n = e.parentNode.parentNode.querySelectorAll("input");
                            for (let e = 0; e < n.length; e++) n[e].disabled = t
                        } else e.disabled = t
                    }

                    function vn() {
                        fn(this, ["confirmButton", "denyButton", "cancelButton"], !1)
                    }

                    function bn() {
                        fn(this, ["confirmButton", "denyButton", "cancelButton"], !0)
                    }

                    function wn() {
                        return gn(this.getInput(), !1)
                    }

                    function yn() {
                        return gn(this.getInput(), !0)
                    }

                    function Cn(e) {
                        const t = Ie.domCache.get(this),
                            n = Ie.innerParams.get(this);
                        W(t.validationMessage, e), t.validationMessage.className = w["validation-message"], n.customClass && n.customClass.validationMessage && Q(t.validationMessage, n.customClass.validationMessage), se(t.validationMessage);
                        const s = this.getInput();
                        s && (s.setAttribute("aria-invalid", !0), s.setAttribute("aria-describedby", w["validation-message"]), Z(s), Q(s, w.inputerror))
                    }

                    function Tn() {
                        const e = Ie.domCache.get(this);
                        e.validationMessage && ie(e.validationMessage);
                        const t = this.getInput();
                        t && (t.removeAttribute("aria-invalid"), t.removeAttribute("aria-describedby"), ee(t, w.inputerror))
                    }

                    function Sn() {
                        return Ie.domCache.get(this).progressSteps
                    }
                    class xn {
                        constructor(e, t) {
                            this.callback = e, this.remaining = t, this.running = !1, this.start()
                        }
                        start() {
                            return this.running || (this.running = !0, this.started = new Date, this.id = setTimeout(this.callback, this.remaining)), this.remaining
                        }
                        stop() {
                            return this.running && (this.running = !1, clearTimeout(this.id), this.remaining -= new Date - this.started), this.remaining
                        }
                        increase(e) {
                            const t = this.running;
                            return t && this.stop(), this.remaining += e, t && this.start(), this.remaining
                        }
                        getTimerLeft() {
                            return this.running && (this.stop(), this.start()), this.remaining
                        }
                        isRunning() {
                            return this.running
                        }
                    }
                    var En = {
                        email: (e, t) => /^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.-]+\.[a-zA-Z0-9-]{2,24}$/.test(e) ? Promise.resolve() : Promise.resolve(t || "Invalid email address"),
                        url: (e, t) => /^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-z]{2,63}\b([-a-zA-Z0-9@:%_+.~#?&/=]*)$/.test(e) ? Promise.resolve() : Promise.resolve(t || "Invalid URL")
                    };

                    function kn(e) {
                        e.inputValidator || Object.keys(En).forEach((t => {
                            e.input === t && (e.inputValidator = En[t])
                        }))
                    }

                    function Pn(e) {
                        (!e.target || "string" == typeof e.target && !document.querySelector(e.target) || "string" != typeof e.target && !e.target.appendChild) && (o('Target parameter is not valid, defaulting to "body"'), e.target = "body")
                    }

                    function On(e) {
                        kn(e), e.showLoaderOnConfirm && !e.preConfirm && o("showLoaderOnConfirm is set to true, but preConfirm is not defined.\nshowLoaderOnConfirm should be used together with preConfirm, see usage example:\nhttps://sweetalert2.github.io/#ajax-request"), Pn(e), "string" == typeof e.title && (e.title = e.title.split("\n").join("<br />")), Ce(e)
                    }
                    const An = ["swal-title", "swal-html", "swal-footer"],
                        Mn = e => {
                            const t = "string" == typeof e.template ? document.querySelector(e.template) : e.template;
                            if (!t) return {};
                            const n = t.content;
                            return zn(n), Object.assign(Ln(n), Bn(n), $n(n), In(n), Dn(n), jn(n, An))
                        },
                        Ln = e => {
                            const t = {};
                            return i(e.querySelectorAll("swal-param")).forEach((e => {
                                Nn(e, ["name", "value"]);
                                const n = e.getAttribute("name");
                                let s = e.getAttribute("value");
                                "boolean" == typeof Mt[n] && "false" === s && (s = !1), "object" == typeof Mt[n] && (s = JSON.parse(s)), t[n] = s
                            })), t
                        },
                        Bn = e => {
                            const t = {};
                            return i(e.querySelectorAll("swal-button")).forEach((e => {
                                Nn(e, ["type", "color", "aria-label"]);
                                const n = e.getAttribute("type");
                                t["".concat(n, "ButtonText")] = e.innerHTML, t["show".concat(s(n), "Button")] = !0, e.hasAttribute("color") && (t["".concat(n, "ButtonColor")] = e.getAttribute("color")), e.hasAttribute("aria-label") && (t["".concat(n, "ButtonAriaLabel")] = e.getAttribute("aria-label"))
                            })), t
                        },
                        $n = e => {
                            const t = {},
                                n = e.querySelector("swal-image");
                            return n && (Nn(n, ["src", "width", "height", "alt"]), n.hasAttribute("src") && (t.imageUrl = n.getAttribute("src")), n.hasAttribute("width") && (t.imageWidth = n.getAttribute("width")), n.hasAttribute("height") && (t.imageHeight = n.getAttribute("height")), n.hasAttribute("alt") && (t.imageAlt = n.getAttribute("alt"))), t
                        },
                        In = e => {
                            const t = {},
                                n = e.querySelector("swal-icon");
                            return n && (Nn(n, ["type", "color"]), n.hasAttribute("type") && (t.icon = n.getAttribute("type")), n.hasAttribute("color") && (t.iconColor = n.getAttribute("color")), t.iconHtml = n.innerHTML), t
                        },
                        Dn = e => {
                            const t = {},
                                n = e.querySelector("swal-input");
                            n && (Nn(n, ["type", "label", "placeholder", "value"]), t.input = n.getAttribute("type") || "text", n.hasAttribute("label") && (t.inputLabel = n.getAttribute("label")), n.hasAttribute("placeholder") && (t.inputPlaceholder = n.getAttribute("placeholder")), n.hasAttribute("value") && (t.inputValue = n.getAttribute("value")));
                            const s = e.querySelectorAll("swal-input-option");
                            return s.length && (t.inputOptions = {}, i(s).forEach((e => {
                                Nn(e, ["value"]);
                                const n = e.getAttribute("value"),
                                    s = e.innerHTML;
                                t.inputOptions[n] = s
                            }))), t
                        },
                        jn = (e, t) => {
                            const n = {};
                            for (const s in t) {
                                const i = t[s],
                                    o = e.querySelector(i);
                                o && (Nn(o, []), n[i.replace(/^swal-/, "")] = o.innerHTML.trim())
                            }
                            return n
                        },
                        zn = e => {
                            const t = An.concat(["swal-param", "swal-button", "swal-image", "swal-icon", "swal-input", "swal-input-option"]);
                            i(e.children).forEach((e => {
                                const n = e.tagName.toLowerCase(); - 1 === t.indexOf(n) && o("Unrecognized element <".concat(n, ">"))
                            }))
                        },
                        Nn = (e, t) => {
                            i(e.attributes).forEach((n => {
                                -1 === t.indexOf(n.name) && o(['Unrecognized attribute "'.concat(n.name, '" on <').concat(e.tagName.toLowerCase(), ">."), "".concat(t.length ? "Allowed attributes are: ".concat(t.join(", ")) : "To set the value, use HTML within the element.")])
                            }))
                        },
                        Hn = 10,
                        _n = e => {
                            const t = C(),
                                n = x();
                            "function" == typeof e.willOpen && e.willOpen(n);
                            const s = window.getComputedStyle(document.body).overflowY;
                            Fn(t, n, e), setTimeout((() => {
                                Vn(t, n)
                            }), Hn), V() && (qn(t, e.scrollbarPadding, s), en()), q() || vt.previousActiveElement || (vt.previousActiveElement = document.activeElement), "function" == typeof e.didOpen && setTimeout((() => e.didOpen(n))), ee(t, w["no-transition"])
                        },
                        Gn = e => {
                            const t = x();
                            if (e.target !== t) return;
                            const n = C();
                            t.removeEventListener(Ee, Gn), n.style.overflowY = "auto"
                        },
                        Vn = (e, t) => {
                            Ee && de(t) ? (e.style.overflowY = "hidden", t.addEventListener(Ee, Gn)) : e.style.overflowY = "auto"
                        },
                        qn = (e, t, n) => {
                            Yt(), t && "hidden" !== n && Rt(), setTimeout((() => {
                                e.scrollTop = 0
                            }))
                        },
                        Fn = (e, t, n) => {
                            Q(e, n.showClass.backdrop), t.style.setProperty("opacity", "0", "important"), se(t, "grid"), setTimeout((() => {
                                Q(t, n.showClass.popup), t.style.removeProperty("opacity")
                            }), Hn), Q([document.documentElement, document.body], w.shown), n.heightAuto && n.backdrop && !n.toast && Q([document.documentElement, document.body], w["height-auto"])
                        },
                        Rn = (e, t) => {
                            "select" === t.input || "radio" === t.input ? Kn(e, t) : ["text", "email", "number", "tel", "textarea"].includes(t.input) && (u(t.inputValue) || h(t.inputValue)) && (mt(L()), Zn(e, t))
                        },
                        Wn = (e, t) => {
                            const n = e.getInput();
                            if (!n) return null;
                            switch (t.input) {
                                case "checkbox":
                                    return Yn(n);
                                case "radio":
                                    return Un(n);
                                case "file":
                                    return Xn(n);
                                default:
                                    return t.inputAutoTrim ? n.value.trim() : n.value
                            }
                        },
                        Yn = e => e.checked ? 1 : 0,
                        Un = e => e.checked ? e.value : null,
                        Xn = e => e.files.length ? null !== e.getAttribute("multiple") ? e.files : e.files[0] : null,
                        Kn = (e, t) => {
                            const n = x(),
                                s = e => Jn[t.input](n, Qn(e), t);
                            u(t.inputOptions) || h(t.inputOptions) ? (mt(L()), p(t.inputOptions).then((t => {
                                e.hideLoading(), s(t)
                            }))) : "object" == typeof t.inputOptions ? s(t.inputOptions) : r("Unexpected type of inputOptions! Expected object, Map or Promise, got ".concat(typeof t.inputOptions))
                        },
                        Zn = (e, t) => {
                            const n = e.getInput();
                            ie(n), p(t.inputValue).then((s => {
                                n.value = "number" === t.input ? parseFloat(s) || 0 : "".concat(s), se(n), n.focus(), e.hideLoading()
                            })).catch((t => {
                                r("Error in inputValue promise: ".concat(t)), n.value = "", se(n), n.focus(), e.hideLoading()
                            }))
                        },
                        Jn = {
                            select: (e, t, n) => {
                                const s = te(e, w.select),
                                    i = (e, t, s) => {
                                        const i = document.createElement("option");
                                        i.value = s, W(i, t), i.selected = es(s, n.inputValue), e.appendChild(i)
                                    };
                                t.forEach((e => {
                                    const t = e[0],
                                        n = e[1];
                                    if (Array.isArray(n)) {
                                        const e = document.createElement("optgroup");
                                        e.label = t, e.disabled = !1, s.appendChild(e), n.forEach((t => i(e, t[1], t[0])))
                                    } else i(s, n, t)
                                })), s.focus()
                            },
                            radio: (e, t, n) => {
                                const s = te(e, w.radio);
                                t.forEach((e => {
                                    const t = e[0],
                                        i = e[1],
                                        o = document.createElement("input"),
                                        r = document.createElement("label");
                                    o.type = "radio", o.name = w.radio, o.value = t, es(t, n.inputValue) && (o.checked = !0);
                                    const a = document.createElement("span");
                                    W(a, i), a.className = w.label, r.appendChild(o), r.appendChild(a), s.appendChild(r)
                                }));
                                const i = s.querySelectorAll("input");
                                i.length && i[0].focus()
                            }
                        },
                        Qn = e => {
                            const t = [];
                            return "undefined" != typeof Map && e instanceof Map ? e.forEach(((e, n) => {
                                let s = e;
                                "object" == typeof s && (s = Qn(s)), t.push([n, s])
                            })) : Object.keys(e).forEach((n => {
                                let s = e[n];
                                "object" == typeof s && (s = Qn(s)), t.push([n, s])
                            })), t
                        },
                        es = (e, t) => t && t.toString() === e.toString(),
                        ts = e => {
                            const t = Ie.innerParams.get(e);
                            e.disableButtons(), t.input ? is(e, "confirm") : cs(e, !0)
                        },
                        ns = e => {
                            const t = Ie.innerParams.get(e);
                            e.disableButtons(), t.returnInputValueOnDeny ? is(e, "deny") : rs(e, !1)
                        },
                        ss = (t, n) => {
                            t.disableButtons(), n(e.cancel)
                        },
                        is = (e, t) => {
                            const n = Ie.innerParams.get(e),
                                s = Wn(e, n);
                            n.inputValidator ? os(e, s, t) : e.getInput().checkValidity() ? "deny" === t ? rs(e, s) : cs(e, s) : (e.enableButtons(), e.showValidationMessage(n.validationMessage))
                        },
                        os = (e, t, n) => {
                            const s = Ie.innerParams.get(e);
                            e.disableInput(), Promise.resolve().then((() => p(s.inputValidator(t, s.validationMessage)))).then((s => {
                                e.enableButtons(), e.enableInput(), s ? e.showValidationMessage(s) : "deny" === n ? rs(e, t) : cs(e, t)
                            }))
                        },
                        rs = (e, t) => {
                            const n = Ie.innerParams.get(e || void 0);
                            n.showLoaderOnDeny && mt(B()), n.preDeny ? (Ie.awaitingPromise.set(e || void 0, !0), Promise.resolve().then((() => p(n.preDeny(t, n.validationMessage)))).then((n => {
                                !1 === n ? e.hideLoading() : e.closePopup({
                                    isDenied: !0,
                                    value: void 0 === n ? t : n
                                })
                            })).catch((t => ls(e || void 0, t)))) : e.closePopup({
                                isDenied: !0,
                                value: t
                            })
                        },
                        as = (e, t) => {
                            e.closePopup({
                                isConfirmed: !0,
                                value: t
                            })
                        },
                        ls = (e, t) => {
                            e.rejectPromise(t)
                        },
                        cs = (e, t) => {
                            const n = Ie.innerParams.get(e || void 0);
                            n.showLoaderOnConfirm && mt(), n.preConfirm ? (e.resetValidationMessage(), Ie.awaitingPromise.set(e || void 0, !0), Promise.resolve().then((() => p(n.preConfirm(t, n.validationMessage)))).then((n => {
                                ae(M()) || !1 === n ? e.hideLoading() : as(e, void 0 === n ? t : n)
                            })).catch((t => ls(e || void 0, t)))) : as(e, t)
                        },
                        ds = (e, t, n, s) => {
                            t.keydownTarget && t.keydownHandlerAdded && (t.keydownTarget.removeEventListener("keydown", t.keydownHandler, {
                                capture: t.keydownListenerCapture
                            }), t.keydownHandlerAdded = !1), n.toast || (t.keydownHandler = t => ms(e, t, s), t.keydownTarget = n.keydownListenerCapture ? window : x(), t.keydownListenerCapture = n.keydownListenerCapture, t.keydownTarget.addEventListener("keydown", t.keydownHandler, {
                                capture: t.keydownListenerCapture
                            }), t.keydownHandlerAdded = !0)
                        },
                        us = (e, t, n) => {
                            const s = G();
                            if (s.length) return (t += n) === s.length ? t = 0 : -1 === t && (t = s.length - 1), s[t].focus();
                            x().focus()
                        },
                        ps = ["ArrowRight", "ArrowDown"],
                        hs = ["ArrowLeft", "ArrowUp"],
                        ms = (e, t, n) => {
                            const s = Ie.innerParams.get(e);
                            s && (s.stopKeydownPropagation && t.stopPropagation(), "Enter" === t.key ? fs(e, t, s) : "Tab" === t.key ? gs(t, s) : [...ps, ...hs].includes(t.key) ? vs(t.key) : "Escape" === t.key && bs(t, s, n))
                        },
                        fs = (e, t, n) => {
                            if (!t.isComposing && t.target && e.getInput() && t.target.outerHTML === e.getInput().outerHTML) {
                                if (["textarea", "file"].includes(n.input)) return;
                                ct(), t.preventDefault()
                            }
                        },
                        gs = (e, t) => {
                            const n = e.target,
                                s = G();
                            let i = -1;
                            for (let e = 0; e < s.length; e++)
                                if (n === s[e]) {
                                    i = e;
                                    break
                                }
                            e.shiftKey ? us(t, i, -1) : us(t, i, 1), e.stopPropagation(), e.preventDefault()
                        },
                        vs = e => {
                            if (![L(), B(), D()].includes(document.activeElement)) return;
                            const t = ps.includes(e) ? "nextElementSibling" : "previousElementSibling",
                                n = document.activeElement[t];
                            n && n.focus()
                        },
                        bs = (t, n, s) => {
                            d(n.allowEscapeKey) && (t.preventDefault(), s(e.esc))
                        },
                        ws = (e, t, n) => {
                            Ie.innerParams.get(e).toast ? ys(e, t, n) : (Ts(t), Ss(t), xs(e, t, n))
                        },
                        ys = (t, n, s) => {
                            n.popup.onclick = () => {
                                const n = Ie.innerParams.get(t);
                                n.showConfirmButton || n.showDenyButton || n.showCancelButton || n.showCloseButton || n.timer || n.input || s(e.close)
                            }
                        };
                    let Cs = !1;
                    const Ts = e => {
                            e.popup.onmousedown = () => {
                                e.container.onmouseup = function(t) {
                                    e.container.onmouseup = void 0, t.target === e.container && (Cs = !0)
                                }
                            }
                        },
                        Ss = e => {
                            e.container.onmousedown = () => {
                                e.popup.onmouseup = function(t) {
                                    e.popup.onmouseup = void 0, (t.target === e.popup || e.popup.contains(t.target)) && (Cs = !0)
                                }
                            }
                        },
                        xs = (t, n, s) => {
                            n.container.onclick = i => {
                                const o = Ie.innerParams.get(t);
                                Cs ? Cs = !1 : i.target === n.container && d(o.allowOutsideClick) && s(e.backdrop)
                            }
                        };

                    function Es(e, t = {}) {
                        _t(Object.assign({}, t, e)), vt.currentInstance && (vt.currentInstance._destroy(), V() && tn()), vt.currentInstance = this;
                        const n = ks(e, t);
                        On(n), Object.freeze(n), vt.timeout && (vt.timeout.stop(), delete vt.timeout), clearTimeout(vt.restoreFocusTimeout);
                        const s = Os(this);
                        return at(this, n), Ie.innerParams.set(this, n), Ps(this, s, n)
                    }
                    const ks = (e, t) => {
                            const n = Mn(e),
                                s = Object.assign({}, Mt, t, n, e);
                            return s.showClass = Object.assign({}, Mt.showClass, s.showClass), s.hideClass = Object.assign({}, Mt.hideClass, s.hideClass), s
                        },
                        Ps = (t, n, s) => new Promise(((i, o) => {
                            const r = e => {
                                t.closePopup({
                                    isDismissed: !0,
                                    dismiss: e
                                })
                            };
                            nn.swalPromiseResolve.set(t, i), nn.swalPromiseReject.set(t, o), n.confirmButton.onclick = () => ts(t), n.denyButton.onclick = () => ns(t), n.cancelButton.onclick = () => ss(t, r), n.closeButton.onclick = () => r(e.close), ws(t, n, r), ds(t, vt, s, r), Rn(t, s), _n(s), As(vt, s, r), Ms(n, s), setTimeout((() => {
                                n.container.scrollTop = 0
                            }))
                        })),
                        Os = e => {
                            const t = {
                                popup: x(),
                                container: C(),
                                actions: j(),
                                confirmButton: L(),
                                denyButton: B(),
                                cancelButton: D(),
                                loader: I(),
                                closeButton: H(),
                                validationMessage: M(),
                                progressSteps: A()
                            };
                            return Ie.domCache.set(e, t), t
                        },
                        As = (e, t, n) => {
                            const s = N();
                            ie(s), t.timer && (e.timeout = new xn((() => {
                                n("timer"), delete e.timeout
                            }), t.timer), t.timerProgressBar && (se(s), setTimeout((() => {
                                e.timeout && e.timeout.running && ue(t.timer)
                            }))))
                        },
                        Ms = (e, t) => {
                            if (!t.toast) return d(t.allowEnterKey) ? void(Ls(e, t) || us(t, -1, 1)) : Bs()
                        },
                        Ls = (e, t) => t.focusDeny && ae(e.denyButton) ? (e.denyButton.focus(), !0) : t.focusCancel && ae(e.cancelButton) ? (e.cancelButton.focus(), !0) : !(!t.focusConfirm || !ae(e.confirmButton) || (e.confirmButton.focus(), 0)),
                        Bs = () => {
                            document.activeElement && "function" == typeof document.activeElement.blur && document.activeElement.blur()
                        };

                    function $s(e) {
                        const t = x(),
                            n = Ie.innerParams.get(this);
                        if (!t || Y(t, n.hideClass.popup)) return o("You're trying to update the closed or closing popup, that won't work. Use the update() method in preConfirm parameter or show a new popup.");
                        const s = {};
                        Object.keys(e).forEach((t => {
                            Gs.isUpdatableParameter(t) ? s[t] = e[t] : o('Invalid parameter to update: "'.concat(t, '". Updatable params are listed here: https://github.com/sweetalert2/sweetalert2/blob/master/src/utils/params.js\n\nIf you think this parameter should be updatable, request it here: https://github.com/sweetalert2/sweetalert2/issues/new?template=02_feature_request.md'))
                        }));
                        const i = Object.assign({}, n, s);
                        at(this, i), Ie.innerParams.set(this, i), Object.defineProperties(this, {
                            params: {
                                value: Object.assign({}, this.params, e),
                                writable: !1,
                                enumerable: !0
                            }
                        })
                    }

                    function Is() {
                        const e = Ie.domCache.get(this),
                            t = Ie.innerParams.get(this);
                        t ? (e.popup && vt.swalCloseEventFinishedCallback && (vt.swalCloseEventFinishedCallback(), delete vt.swalCloseEventFinishedCallback), vt.deferDisposalTimer && (clearTimeout(vt.deferDisposalTimer), delete vt.deferDisposalTimer), "function" == typeof t.didDestroy && t.didDestroy(), Ds(this)) : js(this)
                    }
                    const Ds = e => {
                            js(e), delete e.params, delete vt.keydownHandler, delete vt.keydownTarget, delete vt.currentInstance
                        },
                        js = e => {
                            e.isAwaitingPromise() ? (zs(Ie, e), Ie.awaitingPromise.set(e, !0)) : (zs(nn, e), zs(Ie, e))
                        },
                        zs = (e, t) => {
                            for (const n in e) e[n].delete(t)
                        };
                    var Ns = Object.freeze({
                        hideLoading: Vt,
                        disableLoading: Vt,
                        getInput: Ft,
                        close: rn,
                        isAwaitingPromise: an,
                        rejectPromise: cn,
                        closePopup: rn,
                        closeModal: rn,
                        closeToast: rn,
                        enableButtons: vn,
                        disableButtons: bn,
                        enableInput: wn,
                        disableInput: yn,
                        showValidationMessage: Cn,
                        resetValidationMessage: Tn,
                        getProgressSteps: Sn,
                        _main: Es,
                        update: $s,
                        _destroy: Is
                    });
                    let Hs;
                    class _s {
                        constructor(...e) {
                            if ("undefined" == typeof window) return;
                            Hs = this;
                            const t = Object.freeze(this.constructor.argsToParams(e));
                            Object.defineProperties(this, {
                                params: {
                                    value: t,
                                    writable: !1,
                                    enumerable: !0,
                                    configurable: !0
                                }
                            });
                            const n = this._main(this.params);
                            Ie.promise.set(this, n)
                        }
                        then(e) {
                            return Ie.promise.get(this).then(e)
                        } finally(e) {
                            return Ie.promise.get(this).finally(e)
                        }
                    }
                    Object.assign(_s.prototype, Ns), Object.assign(_s, Gt), Object.keys(Ns).forEach((e => {
                        _s[e] = function(...t) {
                            if (Hs) return Hs[e](...t)
                        }
                    })), _s.DismissReason = e, _s.version = "11.1.9";
                    const Gs = _s;
                    return Gs.default = Gs, Gs
                }(), void 0 !== this && this.Sweetalert2 && (this.swal = this.sweetAlert = this.Swal = this.SweetAlert = this.Sweetalert2)
            }
        },
        t = {};

    function n(s) {
        var i = t[s];
        if (void 0 !== i) return i.exports;
        var o = t[s] = {
            exports: {}
        };
        return e[s].call(o.exports, o, o.exports, n), o.exports
    }
    n.n = e => {
        var t = e && e.__esModule ? () => e.default : () => e;
        return n.d(t, {
            a: t
        }), t
    }, n.d = (e, t) => {
        for (var s in t) n.o(t, s) && !n.o(e, s) && Object.defineProperty(e, s, {
            enumerable: !0,
            get: t[s]
        })
    }, n.o = (e, t) => Object.prototype.hasOwnProperty.call(e, t), (() => {
        "use strict";

        function e(e) {
            return null !== e && "object" == typeof e && "constructor" in e && e.constructor === Object
        }

        function t(n = {}, s = {}) {
            Object.keys(s).forEach((i => {
                void 0 === n[i] ? n[i] = s[i] : e(s[i]) && e(n[i]) && Object.keys(s[i]).length > 0 && t(n[i], s[i])
            }))
        }
        const s = {
            body: {},
            addEventListener() {},
            removeEventListener() {},
            activeElement: {
                blur() {},
                nodeName: ""
            },
            querySelector: () => null,
            querySelectorAll: () => [],
            getElementById: () => null,
            createEvent: () => ({
                initEvent() {}
            }),
            createElement: () => ({
                children: [],
                childNodes: [],
                style: {},
                setAttribute() {},
                getElementsByTagName: () => []
            }),
            createElementNS: () => ({}),
            importNode: () => null,
            location: {
                hash: "",
                host: "",
                hostname: "",
                href: "",
                origin: "",
                pathname: "",
                protocol: "",
                search: ""
            }
        };

        function i() {
            const e = "undefined" != typeof document ? document : {};
            return t(e, s), e
        }
        const o = {
            document: s,
            navigator: {
                userAgent: ""
            },
            location: {
                hash: "",
                host: "",
                hostname: "",
                href: "",
                origin: "",
                pathname: "",
                protocol: "",
                search: ""
            },
            history: {
                replaceState() {},
                pushState() {},
                go() {},
                back() {}
            },
            CustomEvent: function() {
                return this
            },
            addEventListener() {},
            removeEventListener() {},
            getComputedStyle: () => ({
                getPropertyValue: () => ""
            }),
            Image() {},
            Date() {},
            screen: {},
            setTimeout() {},
            clearTimeout() {},
            matchMedia: () => ({}),
            requestAnimationFrame: e => "undefined" == typeof setTimeout ? (e(), null) : setTimeout(e, 0),
            cancelAnimationFrame(e) {
                "undefined" != typeof setTimeout && clearTimeout(e)
            }
        };

        function r() {
            const e = "undefined" != typeof window ? window : {};
            return t(e, o), e
        }
        class a extends Array {
            constructor(e) {
                super(...e || []),
                    function(e) {
                        const t = e.__proto__;
                        Object.defineProperty(e, "__proto__", {
                            get: () => t,
                            set(e) {
                                t.__proto__ = e
                            }
                        })
                    }(this)
            }
        }

        function l(e = []) {
            const t = [];
            return e.forEach((e => {
                Array.isArray(e) ? t.push(...l(e)) : t.push(e)
            })), t
        }

        function c(e, t) {
            return Array.prototype.filter.call(e, t)
        }

        function d(e, t) {
            const n = r(),
                s = i();
            let o = [];
            if (!t && e instanceof a) return e;
            if (!e) return new a(o);
            if ("string" == typeof e) {
                const n = e.trim();
                if (n.indexOf("<") >= 0 && n.indexOf(">") >= 0) {
                    let e = "div";
                    0 === n.indexOf("<li") && (e = "ul"), 0 === n.indexOf("<tr") && (e = "tbody"), 0 !== n.indexOf("<td") && 0 !== n.indexOf("<th") || (e = "tr"), 0 === n.indexOf("<tbody") && (e = "table"), 0 === n.indexOf("<option") && (e = "select");
                    const t = s.createElement(e);
                    t.innerHTML = n;
                    for (let e = 0; e < t.childNodes.length; e += 1) o.push(t.childNodes[e])
                } else o = function(e, t) {
                    if ("string" != typeof e) return [e];
                    const n = [],
                        s = t.querySelectorAll(e);
                    for (let e = 0; e < s.length; e += 1) n.push(s[e]);
                    return n
                }(e.trim(), t || s)
            } else if (e.nodeType || e === n || e === s) o.push(e);
            else if (Array.isArray(e)) {
                if (e instanceof a) return e;
                o = e
            }
            return new a(function(e) {
                const t = [];
                for (let n = 0; n < e.length; n += 1) - 1 === t.indexOf(e[n]) && t.push(e[n]);
                return t
            }(o))
        }
        d.fn = a.prototype;
        const u = "resize scroll".split(" ");

        function p(e) {
            return function(...t) {
                if (void 0 === t[0]) {
                    for (let t = 0; t < this.length; t += 1) u.indexOf(e) < 0 && (e in this[t] ? this[t][e]() : d(this[t]).trigger(e));
                    return this
                }
                return this.on(e, ...t)
            }
        }
        p("click"), p("blur"), p("focus"), p("focusin"), p("focusout"), p("keyup"), p("keydown"), p("keypress"), p("submit"), p("change"), p("mousedown"), p("mousemove"), p("mouseup"), p("mouseenter"), p("mouseleave"), p("mouseout"), p("mouseover"), p("touchstart"), p("touchend"), p("touchmove"), p("resize"), p("scroll");
        const h = {
            addClass: function(...e) {
                const t = l(e.map((e => e.split(" "))));
                return this.forEach((e => {
                    e.classList.add(...t)
                })), this
            },
            removeClass: function(...e) {
                const t = l(e.map((e => e.split(" "))));
                return this.forEach((e => {
                    e.classList.remove(...t)
                })), this
            },
            hasClass: function(...e) {
                const t = l(e.map((e => e.split(" "))));
                return c(this, (e => t.filter((t => e.classList.contains(t))).length > 0)).length > 0
            },
            toggleClass: function(...e) {
                const t = l(e.map((e => e.split(" "))));
                this.forEach((e => {
                    t.forEach((t => {
                        e.classList.toggle(t)
                    }))
                }))
            },
            attr: function(e, t) {
                if (1 === arguments.length && "string" == typeof e) return this[0] ? this[0].getAttribute(e) : void 0;
                for (let n = 0; n < this.length; n += 1)
                    if (2 === arguments.length) this[n].setAttribute(e, t);
                    else
                        for (const t in e) this[n][t] = e[t], this[n].setAttribute(t, e[t]);
                return this
            },
            removeAttr: function(e) {
                for (let t = 0; t < this.length; t += 1) this[t].removeAttribute(e);
                return this
            },
            transform: function(e) {
                for (let t = 0; t < this.length; t += 1) this[t].style.transform = e;
                return this
            },
            transition: function(e) {
                for (let t = 0; t < this.length; t += 1) this[t].style.transitionDuration = "string" != typeof e ? `${e}ms` : e;
                return this
            },
            on: function(...e) {
                let [t, n, s, i] = e;

                function o(e) {
                    const t = e.target;
                    if (!t) return;
                    const i = e.target.dom7EventData || [];
                    if (i.indexOf(e) < 0 && i.unshift(e), d(t).is(n)) s.apply(t, i);
                    else {
                        const e = d(t).parents();
                        for (let t = 0; t < e.length; t += 1) d(e[t]).is(n) && s.apply(e[t], i)
                    }
                }

                function r(e) {
                    const t = e && e.target && e.target.dom7EventData || [];
                    t.indexOf(e) < 0 && t.unshift(e), s.apply(this, t)
                }
                "function" == typeof e[1] && ([t, s, i] = e, n = void 0), i || (i = !1);
                const a = t.split(" ");
                let l;
                for (let e = 0; e < this.length; e += 1) {
                    const t = this[e];
                    if (n)
                        for (l = 0; l < a.length; l += 1) {
                            const e = a[l];
                            t.dom7LiveListeners || (t.dom7LiveListeners = {}), t.dom7LiveListeners[e] || (t.dom7LiveListeners[e] = []), t.dom7LiveListeners[e].push({
                                listener: s,
                                proxyListener: o
                            }), t.addEventListener(e, o, i)
                        } else
                            for (l = 0; l < a.length; l += 1) {
                                const e = a[l];
                                t.dom7Listeners || (t.dom7Listeners = {}), t.dom7Listeners[e] || (t.dom7Listeners[e] = []), t.dom7Listeners[e].push({
                                    listener: s,
                                    proxyListener: r
                                }), t.addEventListener(e, r, i)
                            }
                }
                return this
            },
            off: function(...e) {
                let [t, n, s, i] = e;
                "function" == typeof e[1] && ([t, s, i] = e, n = void 0), i || (i = !1);
                const o = t.split(" ");
                for (let e = 0; e < o.length; e += 1) {
                    const t = o[e];
                    for (let e = 0; e < this.length; e += 1) {
                        const o = this[e];
                        let r;
                        if (!n && o.dom7Listeners ? r = o.dom7Listeners[t] : n && o.dom7LiveListeners && (r = o.dom7LiveListeners[t]), r && r.length)
                            for (let e = r.length - 1; e >= 0; e -= 1) {
                                const n = r[e];
                                s && n.listener === s || s && n.listener && n.listener.dom7proxy && n.listener.dom7proxy === s ? (o.removeEventListener(t, n.proxyListener, i), r.splice(e, 1)) : s || (o.removeEventListener(t, n.proxyListener, i), r.splice(e, 1))
                            }
                    }
                }
                return this
            },
            trigger: function(...e) {
                const t = r(),
                    n = e[0].split(" "),
                    s = e[1];
                for (let i = 0; i < n.length; i += 1) {
                    const o = n[i];
                    for (let n = 0; n < this.length; n += 1) {
                        const i = this[n];
                        if (t.CustomEvent) {
                            const n = new t.CustomEvent(o, {
                                detail: s,
                                bubbles: !0,
                                cancelable: !0
                            });
                            i.dom7EventData = e.filter(((e, t) => t > 0)), i.dispatchEvent(n), i.dom7EventData = [], delete i.dom7EventData
                        }
                    }
                }
                return this
            },
            transitionEnd: function(e) {
                const t = this;
                return e && t.on("transitionend", (function n(s) {
                    s.target === this && (e.call(this, s), t.off("transitionend", n))
                })), this
            },
            outerWidth: function(e) {
                if (this.length > 0) {
                    if (e) {
                        const e = this.styles();
                        return this[0].offsetWidth + parseFloat(e.getPropertyValue("margin-right")) + parseFloat(e.getPropertyValue("margin-left"))
                    }
                    return this[0].offsetWidth
                }
                return null
            },
            outerHeight: function(e) {
                if (this.length > 0) {
                    if (e) {
                        const e = this.styles();
                        return this[0].offsetHeight + parseFloat(e.getPropertyValue("margin-top")) + parseFloat(e.getPropertyValue("margin-bottom"))
                    }
                    return this[0].offsetHeight
                }
                return null
            },
            styles: function() {
                const e = r();
                return this[0] ? e.getComputedStyle(this[0], null) : {}
            },
            offset: function() {
                if (this.length > 0) {
                    const e = r(),
                        t = i(),
                        n = this[0],
                        s = n.getBoundingClientRect(),
                        o = t.body,
                        a = n.clientTop || o.clientTop || 0,
                        l = n.clientLeft || o.clientLeft || 0,
                        c = n === e ? e.scrollY : n.scrollTop,
                        d = n === e ? e.scrollX : n.scrollLeft;
                    return {
                        top: s.top + c - a,
                        right: s.right + d - l
                    }
                }
                return null
            },
            css: function(e, t) {
                const n = r();
                let s;
                if (1 === arguments.length) {
                    if ("string" != typeof e) {
                        for (s = 0; s < this.length; s += 1)
                            for (const t in e) this[s].style[t] = e[t];
                        return this
                    }
                    if (this[0]) return n.getComputedStyle(this[0], null).getPropertyValue(e)
                }
                if (2 === arguments.length && "string" == typeof e) {
                    for (s = 0; s < this.length; s += 1) this[s].style[e] = t;
                    return this
                }
                return this
            },
            each: function(e) {
                return e ? (this.forEach(((t, n) => {
                    e.apply(t, [t, n])
                })), this) : this
            },
            html: function(e) {
                if (void 0 === e) return this[0] ? this[0].innerHTML : null;
                for (let t = 0; t < this.length; t += 1) this[t].innerHTML = e;
                return this
            },
            text: function(e) {
                if (void 0 === e) return this[0] ? this[0].textContent.trim() : null;
                for (let t = 0; t < this.length; t += 1) this[t].textContent = e;
                return this
            },
            is: function(e) {
                const t = r(),
                    n = i(),
                    s = this[0];
                let o, l;
                if (!s || void 0 === e) return !1;
                if ("string" == typeof e) {
                    if (s.matches) return s.matches(e);
                    if (s.webkitMatchesSelector) return s.webkitMatchesSelector(e);
                    if (s.msMatchesSelector) return s.msMatchesSelector(e);
                    for (o = d(e), l = 0; l < o.length; l += 1)
                        if (o[l] === s) return !0;
                    return !1
                }
                if (e === n) return s === n;
                if (e === t) return s === t;
                if (e.nodeType || e instanceof a) {
                    for (o = e.nodeType ? [e] : e, l = 0; l < o.length; l += 1)
                        if (o[l] === s) return !0;
                    return !1
                }
                return !1
            },
            index: function() {
                let e, t = this[0];
                if (t) {
                    for (e = 0; null !== (t = t.previousSibling);) 1 === t.nodeType && (e += 1);
                    return e
                }
            },
            eq: function(e) {
                if (void 0 === e) return this;
                const t = this.length;
                if (e > t - 1) return d([]);
                if (e < 0) {
                    const n = t + e;
                    return d(n < 0 ? [] : [this[n]])
                }
                return d([this[e]])
            },
            append: function(...e) {
                let t;
                const n = i();
                for (let s = 0; s < e.length; s += 1) {
                    t = e[s];
                    for (let e = 0; e < this.length; e += 1)
                        if ("string" == typeof t) {
                            const s = n.createElement("div");
                            for (s.innerHTML = t; s.firstChild;) this[e].appendChild(s.firstChild)
                        } else if (t instanceof a)
                        for (let n = 0; n < t.length; n += 1) this[e].appendChild(t[n]);
                    else this[e].appendChild(t)
                }
                return this
            },
            prepend: function(e) {
                const t = i();
                let n, s;
                for (n = 0; n < this.length; n += 1)
                    if ("string" == typeof e) {
                        const i = t.createElement("div");
                        for (i.innerHTML = e, s = i.childNodes.length - 1; s >= 0; s -= 1) this[n].insertBefore(i.childNodes[s], this[n].childNodes[0])
                    } else if (e instanceof a)
                    for (s = 0; s < e.length; s += 1) this[n].insertBefore(e[s], this[n].childNodes[0]);
                else this[n].insertBefore(e, this[n].childNodes[0]);
                return this
            },
            next: function(e) {
                return this.length > 0 ? e ? this[0].nextElementSibling && d(this[0].nextElementSibling).is(e) ? d([this[0].nextElementSibling]) : d([]) : this[0].nextElementSibling ? d([this[0].nextElementSibling]) : d([]) : d([])
            },
            nextAll: function(e) {
                const t = [];
                let n = this[0];
                if (!n) return d([]);
                for (; n.nextElementSibling;) {
                    const s = n.nextElementSibling;
                    e ? d(s).is(e) && t.push(s) : t.push(s), n = s
                }
                return d(t)
            },
            prev: function(e) {
                if (this.length > 0) {
                    const t = this[0];
                    return e ? t.previousElementSibling && d(t.previousElementSibling).is(e) ? d([t.previousElementSibling]) : d([]) : t.previousElementSibling ? d([t.previousElementSibling]) : d([])
                }
                return d([])
            },
            prevAll: function(e) {
                const t = [];
                let n = this[0];
                if (!n) return d([]);
                for (; n.previousElementSibling;) {
                    const s = n.previousElementSibling;
                    e ? d(s).is(e) && t.push(s) : t.push(s), n = s
                }
                return d(t)
            },
            parent: function(e) {
                const t = [];
                for (let n = 0; n < this.length; n += 1) null !== this[n].parentNode && (e ? d(this[n].parentNode).is(e) && t.push(this[n].parentNode) : t.push(this[n].parentNode));
                return d(t)
            },
            parents: function(e) {
                const t = [];
                for (let n = 0; n < this.length; n += 1) {
                    let s = this[n].parentNode;
                    for (; s;) e ? d(s).is(e) && t.push(s) : t.push(s), s = s.parentNode
                }
                return d(t)
            },
            closest: function(e) {
                let t = this;
                return void 0 === e ? d([]) : (t.is(e) || (t = t.parents(e).eq(0)), t)
            },
            find: function(e) {
                const t = [];
                for (let n = 0; n < this.length; n += 1) {
                    const s = this[n].querySelectorAll(e);
                    for (let e = 0; e < s.length; e += 1) t.push(s[e])
                }
                return d(t)
            },
            children: function(e) {
                const t = [];
                for (let n = 0; n < this.length; n += 1) {
                    const s = this[n].children;
                    for (let n = 0; n < s.length; n += 1) e && !d(s[n]).is(e) || t.push(s[n])
                }
                return d(t)
            },
            filter: function(e) {
                return d(c(this, e))
            },
            remove: function() {
                for (let e = 0; e < this.length; e += 1) this[e].parentNode && this[e].parentNode.removeChild(this[e]);
                return this
            }
        };
        Object.keys(h).forEach((e => {
            Object.defineProperty(d.fn, e, {
                value: h[e],
                writable: !0
            })
        }));
        const m = d;

        function f(e, t = 0) {
            return setTimeout(e, t)
        }

        function g() {
            return Date.now()
        }

        function v(e, t = "x") {
            const n = r();
            let s, i, o;
            const a = function(e) {
                const t = r();
                let n;
                return t.getComputedStyle && (n = t.getComputedStyle(e, null)), !n && e.currentStyle && (n = e.currentStyle), n || (n = e.style), n
            }(e);
            return n.WebKitCSSMatrix ? (i = a.transform || a.webkitTransform, i.split(",").length > 6 && (i = i.split(", ").map((e => e.replace(",", "."))).join(", ")), o = new n.WebKitCSSMatrix("none" === i ? "" : i)) : (o = a.MozTransform || a.OTransform || a.MsTransform || a.msTransform || a.transform || a.getPropertyValue("transform").replace("translate(", "matrix(1, 0, 0, 1,"), s = o.toString().split(",")), "x" === t && (i = n.WebKitCSSMatrix ? o.m41 : 16 === s.length ? parseFloat(s[12]) : parseFloat(s[4])), "y" === t && (i = n.WebKitCSSMatrix ? o.m42 : 16 === s.length ? parseFloat(s[13]) : parseFloat(s[5])), i || 0
        }

        function b(e) {
            return "object" == typeof e && null !== e && e.constructor && "Object" === Object.prototype.toString.call(e).slice(8, -1)
        }

        function w(...e) {
            const t = Object(e[0]),
                n = ["__proto__", "constructor", "prototype"];
            for (let i = 1; i < e.length; i += 1) {
                const o = e[i];
                if (null != o && (s = o, !("undefined" != typeof window && void 0 !== window.HTMLElement ? s instanceof HTMLElement : s && (1 === s.nodeType || 11 === s.nodeType)))) {
                    const e = Object.keys(Object(o)).filter((e => n.indexOf(e) < 0));
                    for (let n = 0, s = e.length; n < s; n += 1) {
                        const s = e[n],
                            i = Object.getOwnPropertyDescriptor(o, s);
                        void 0 !== i && i.enumerable && (b(t[s]) && b(o[s]) ? o[s].__swiper__ ? t[s] = o[s] : w(t[s], o[s]) : !b(t[s]) && b(o[s]) ? (t[s] = {}, o[s].__swiper__ ? t[s] = o[s] : w(t[s], o[s])) : t[s] = o[s])
                    }
                }
            }
            var s;
            return t
        }

        function y(e, t, n) {
            e.style.setProperty(t, n)
        }

        function C({
            swiper: e,
            targetPosition: t,
            side: n
        }) {
            const s = r(),
                i = -e.translate;
            let o, a = null;
            const l = e.params.speed;
            e.wrapperEl.style.scrollSnapType = "none", s.cancelAnimationFrame(e.cssModeFrameID);
            const c = t > i ? "next" : "prev",
                d = (e, t) => "next" === c && e >= t || "prev" === c && e <= t,
                u = () => {
                    o = (new Date).getTime(), null === a && (a = o);
                    const r = Math.max(Math.min((o - a) / l, 1), 0),
                        c = .5 - Math.cos(r * Math.PI) / 2;
                    let p = i + c * (t - i);
                    if (d(p, t) && (p = t), e.wrapperEl.scrollTo({
                            [n]: p
                        }), d(p, t)) return e.wrapperEl.style.overflow = "hidden", e.wrapperEl.style.scrollSnapType = "", setTimeout((() => {
                        e.wrapperEl.style.overflow = "", e.wrapperEl.scrollTo({
                            [n]: p
                        })
                    })), void s.cancelAnimationFrame(e.cssModeFrameID);
                    e.cssModeFrameID = s.requestAnimationFrame(u)
                };
            u()
        }
        let T, S, x;

        function E() {
            return T || (T = function() {
                const e = r(),
                    t = i();
                return {
                    smoothScroll: t.documentElement && "scrollBehavior" in t.documentElement.style,
                    touch: !!("ontouchstart" in e || e.DocumentTouch && t instanceof e.DocumentTouch),
                    passiveListener: function() {
                        let t = !1;
                        try {
                            const n = Object.defineProperty({}, "passive", {
                                get() {
                                    t = !0
                                }
                            });
                            e.addEventListener("testPassiveListener", null, n)
                        } catch (e) {}
                        return t
                    }(),
                    gestures: "ongesturestart" in e
                }
            }()), T
        }

        function k(e = {}) {
            return S || (S = function({
                userAgent: e
            } = {}) {
                const t = E(),
                    n = r(),
                    s = n.navigator.platform,
                    i = e || n.navigator.userAgent,
                    o = {
                        ios: !1,
                        android: !1
                    },
                    a = n.screen.width,
                    l = n.screen.height,
                    c = i.match(/(Android);?[\s\/]+([\d.]+)?/);
                let d = i.match(/(iPad).*OS\s([\d_]+)/);
                const u = i.match(/(iPod)(.*OS\s([\d_]+))?/),
                    p = !d && i.match(/(iPhone\sOS|iOS)\s([\d_]+)/),
                    h = "Win32" === s;
                let m = "MacIntel" === s;
                return !d && m && t.touch && ["1024x1366", "1366x1024", "834x1194", "1194x834", "834x1112", "1112x834", "768x1024", "1024x768", "820x1180", "1180x820", "810x1080", "1080x810"].indexOf(`${a}x${l}`) >= 0 && (d = i.match(/(Version)\/([\d.]+)/), d || (d = [0, 1, "13_0_0"]), m = !1), c && !h && (o.os = "android", o.android = !0), (d || p || u) && (o.os = "ios", o.ios = !0), o
            }(e)), S
        }

        function P() {
            return x || (x = function() {
                const e = r();
                return {
                    isSafari: function() {
                        const t = e.navigator.userAgent.toLowerCase();
                        return t.indexOf("safari") >= 0 && t.indexOf("chrome") < 0 && t.indexOf("android") < 0
                    }(),
                    isWebView: /(iPhone|iPod|iPad).*AppleWebKit(?!.*Safari)/i.test(e.navigator.userAgent)
                }
            }()), x
        }
        const O = {
            on(e, t, n) {
                const s = this;
                if ("function" != typeof t) return s;
                const i = n ? "unshift" : "push";
                return e.split(" ").forEach((e => {
                    s.eventsListeners[e] || (s.eventsListeners[e] = []), s.eventsListeners[e][i](t)
                })), s
            },
            once(e, t, n) {
                const s = this;
                if ("function" != typeof t) return s;

                function i(...n) {
                    s.off(e, i), i.__emitterProxy && delete i.__emitterProxy, t.apply(s, n)
                }
                return i.__emitterProxy = t, s.on(e, i, n)
            },
            onAny(e, t) {
                const n = this;
                if ("function" != typeof e) return n;
                const s = t ? "unshift" : "push";
                return n.eventsAnyListeners.indexOf(e) < 0 && n.eventsAnyListeners[s](e), n
            },
            offAny(e) {
                const t = this;
                if (!t.eventsAnyListeners) return t;
                const n = t.eventsAnyListeners.indexOf(e);
                return n >= 0 && t.eventsAnyListeners.splice(n, 1), t
            },
            off(e, t) {
                const n = this;
                return n.eventsListeners ? (e.split(" ").forEach((e => {
                    void 0 === t ? n.eventsListeners[e] = [] : n.eventsListeners[e] && n.eventsListeners[e].forEach(((s, i) => {
                        (s === t || s.__emitterProxy && s.__emitterProxy === t) && n.eventsListeners[e].splice(i, 1)
                    }))
                })), n) : n
            },
            emit(...e) {
                const t = this;
                if (!t.eventsListeners) return t;
                let n, s, i;
                "string" == typeof e[0] || Array.isArray(e[0]) ? (n = e[0], s = e.slice(1, e.length), i = t) : (n = e[0].events, s = e[0].data, i = e[0].context || t), s.unshift(i);
                return (Array.isArray(n) ? n : n.split(" ")).forEach((e => {
                    t.eventsAnyListeners && t.eventsAnyListeners.length && t.eventsAnyListeners.forEach((t => {
                        t.apply(i, [e, ...s])
                    })), t.eventsListeners && t.eventsListeners[e] && t.eventsListeners[e].forEach((e => {
                        e.apply(i, s)
                    }))
                })), t
            }
        };
        const A = {
            updateSize: function() {
                const e = this;
                let t, n;
                const s = e.$el;
                t = void 0 !== e.params.width && null !== e.params.width ? e.params.width : s[0].clientWidth, n = void 0 !== e.params.height && null !== e.params.height ? e.params.height : s[0].clientHeight, 0 === t && e.isHorizontal() || 0 === n && e.isVertical() || (t = t - parseInt(s.css("padding-left") || 0, 10) - parseInt(s.css("padding-right") || 0, 10), n = n - parseInt(s.css("padding-top") || 0, 10) - parseInt(s.css("padding-bottom") || 0, 10), Number.isNaN(t) && (t = 0), Number.isNaN(n) && (n = 0), Object.assign(e, {
                    width: t,
                    height: n,
                    size: e.isHorizontal() ? t : n
                }))
            },
            updateSlides: function() {
                const e = this;

                function t(t) {
                    return e.isHorizontal() ? t : {
                        width: "height",
                        "margin-top": "margin-left",
                        "margin-bottom ": "margin-right",
                        "margin-left": "margin-top",
                        "margin-right": "margin-bottom",
                        "padding-left": "padding-top",
                        "padding-right": "padding-bottom",
                        marginRight: "marginBottom"
                    }[t]
                }

                function n(e, n) {
                    return parseFloat(e.getPropertyValue(t(n)) || 0)
                }
                const s = e.params,
                    {
                        $wrapperEl: i,
                        size: o,
                        rtlTranslate: r,
                        wrongRTL: a
                    } = e,
                    l = e.virtual && s.virtual.enabled,
                    c = l ? e.virtual.slides.length : e.slides.length,
                    d = i.children(`.${e.params.slideClass}`),
                    u = l ? e.virtual.slides.length : d.length;
                let p = [];
                const h = [],
                    m = [];
                let f = s.slidesOffsetBefore;
                "function" == typeof f && (f = s.slidesOffsetBefore.call(e));
                let g = s.slidesOffsetAfter;
                "function" == typeof g && (g = s.slidesOffsetAfter.call(e));
                const v = e.snapGrid.length,
                    b = e.slidesGrid.length;
                let w = s.spaceBetween,
                    C = -f,
                    T = 0,
                    S = 0;
                if (void 0 === o) return;
                "string" == typeof w && w.indexOf("%") >= 0 && (w = parseFloat(w.replace("%", "")) / 100 * o), e.virtualSize = -w, r ? d.css({
                    marginLeft: "",
                    marginBottom: "",
                    marginTop: ""
                }) : d.css({
                    marginRight: "",
                    marginBottom: "",
                    marginTop: ""
                }), s.centeredSlides && s.cssMode && (y(e.wrapperEl, "--swiper-centered-offset-before", ""), y(e.wrapperEl, "--swiper-centered-offset-after", ""));
                const x = s.grid && s.grid.rows > 1 && e.grid;
                let E;
                x && e.grid.initSlides(u);
                const k = "auto" === s.slidesPerView && s.breakpoints && Object.keys(s.breakpoints).filter((e => void 0 !== s.breakpoints[e].slidesPerView)).length > 0;
                for (let i = 0; i < u; i += 1) {
                    E = 0;
                    const r = d.eq(i);
                    if (x && e.grid.updateSlide(i, r, u, t), "none" !== r.css("display")) {
                        if ("auto" === s.slidesPerView) {
                            k && (d[i].style[t("width")] = "");
                            const o = getComputedStyle(r[0]),
                                a = r[0].style.transform,
                                l = r[0].style.webkitTransform;
                            if (a && (r[0].style.transform = "none"), l && (r[0].style.webkitTransform = "none"), s.roundLengths) E = e.isHorizontal() ? r.outerWidth(!0) : r.outerHeight(!0);
                            else {
                                const e = n(o, "width"),
                                    t = n(o, "padding-left"),
                                    s = n(o, "padding-right"),
                                    i = n(o, "margin-left"),
                                    a = n(o, "margin-right"),
                                    l = o.getPropertyValue("box-sizing");
                                if (l && "border-box" === l) E = e + i + a;
                                else {
                                    const {
                                        clientWidth: n,
                                        offsetWidth: o
                                    } = r[0];
                                    E = e + t + s + i + a + (o - n)
                                }
                            }
                            a && (r[0].style.transform = a), l && (r[0].style.webkitTransform = l), s.roundLengths && (E = Math.floor(E))
                        } else E = (o - (s.slidesPerView - 1) * w) / s.slidesPerView, s.roundLengths && (E = Math.floor(E)), d[i] && (d[i].style[t("width")] = `${E}px`);
                        d[i] && (d[i].swiperSlideSize = E), m.push(E), s.centeredSlides ? (C = C + E / 2 + T / 2 + w, 0 === T && 0 !== i && (C = C - o / 2 - w), 0 === i && (C = C - o / 2 - w), Math.abs(C) < .001 && (C = 0), s.roundLengths && (C = Math.floor(C)), S % s.slidesPerGroup == 0 && p.push(C), h.push(C)) : (s.roundLengths && (C = Math.floor(C)), (S - Math.min(e.params.slidesPerGroupSkip, S)) % e.params.slidesPerGroup == 0 && p.push(C), h.push(C), C = C + E + w), e.virtualSize += E + w, T = E, S += 1
                    }
                }
                if (e.virtualSize = Math.max(e.virtualSize, o) + g, r && a && ("slide" === s.effect || "coverflow" === s.effect) && i.css({
                        width: `${e.virtualSize+s.spaceBetween}px`
                    }), s.setWrapperSize && i.css({
                        [t("width")]: `${e.virtualSize+s.spaceBetween}px`
                    }), x && e.grid.updateWrapperSize(E, p, t), !s.centeredSlides) {
                    const t = [];
                    for (let n = 0; n < p.length; n += 1) {
                        let i = p[n];
                        s.roundLengths && (i = Math.floor(i)), p[n] <= e.virtualSize - o && t.push(i)
                    }
                    p = t, Math.floor(e.virtualSize - o) - Math.floor(p[p.length - 1]) > 1 && p.push(e.virtualSize - o)
                }
                if (0 === p.length && (p = [0]), 0 !== s.spaceBetween) {
                    const n = e.isHorizontal() && r ? "marginLeft" : t("marginRight");
                    d.filter(((e, t) => !s.cssMode || t !== d.length - 1)).css({
                        [n]: `${w}px`
                    })
                }
                if (s.centeredSlides && s.centeredSlidesBounds) {
                    let e = 0;
                    m.forEach((t => {
                        e += t + (s.spaceBetween ? s.spaceBetween : 0)
                    })), e -= s.spaceBetween;
                    const t = e - o;
                    p = p.map((e => e < 0 ? -f : e > t ? t + g : e))
                }
                if (s.centerInsufficientSlides) {
                    let e = 0;
                    if (m.forEach((t => {
                            e += t + (s.spaceBetween ? s.spaceBetween : 0)
                        })), e -= s.spaceBetween, e < o) {
                        const t = (o - e) / 2;
                        p.forEach(((e, n) => {
                            p[n] = e - t
                        })), h.forEach(((e, n) => {
                            h[n] = e + t
                        }))
                    }
                }
                if (Object.assign(e, {
                        slides: d,
                        snapGrid: p,
                        slidesGrid: h,
                        slidesSizesGrid: m
                    }), s.centeredSlides && s.cssMode && !s.centeredSlidesBounds) {
                    y(e.wrapperEl, "--swiper-centered-offset-before", -p[0] + "px"), y(e.wrapperEl, "--swiper-centered-offset-after", e.size / 2 - m[m.length - 1] / 2 + "px");
                    const t = -e.snapGrid[0],
                        n = -e.slidesGrid[0];
                    e.snapGrid = e.snapGrid.map((e => e + t)), e.slidesGrid = e.slidesGrid.map((e => e + n))
                }
                u !== c && e.emit("slidesLengthChange"), p.length !== v && (e.params.watchOverflow && e.checkOverflow(), e.emit("snapGridLengthChange")), h.length !== b && e.emit("slidesGridLengthChange"), s.watchSlidesProgress && e.updateSlidesOffset()
            },
            updateAutoHeight: function(e) {
                const t = this,
                    n = [],
                    s = t.virtual && t.params.virtual.enabled;
                let i, o = 0;
                "number" == typeof e ? t.setTransition(e) : !0 === e && t.setTransition(t.params.speed);
                const r = e => s ? t.slides.filter((t => parseInt(t.getAttribute("data-swiper-slide-index"), 10) === e))[0] : t.slides.eq(e)[0];
                if ("auto" !== t.params.slidesPerView && t.params.slidesPerView > 1)
                    if (t.params.centeredSlides) t.visibleSlides.each((e => {
                        n.push(e)
                    }));
                    else
                        for (i = 0; i < Math.ceil(t.params.slidesPerView); i += 1) {
                            const e = t.activeIndex + i;
                            if (e > t.slides.length && !s) break;
                            n.push(r(e))
                        } else n.push(r(t.activeIndex));
                for (i = 0; i < n.length; i += 1)
                    if (void 0 !== n[i]) {
                        const e = n[i].offsetHeight;
                        o = e > o ? e : o
                    }
                o && t.$wrapperEl.css("height", `${o}px`)
            },
            updateSlidesOffset: function() {
                const e = this,
                    t = e.slides;
                for (let n = 0; n < t.length; n += 1) t[n].swiperSlideOffset = e.isHorizontal() ? t[n].offsetLeft : t[n].offsetTop
            },
            updateSlidesProgress: function(e = this && this.translate || 0) {
                const t = this,
                    n = t.params,
                    {
                        slides: s,
                        rtlTranslate: i,
                        snapGrid: o
                    } = t;
                if (0 === s.length) return;
                void 0 === s[0].swiperSlideOffset && t.updateSlidesOffset();
                let r = -e;
                i && (r = e), s.removeClass(n.slideVisibleClass), t.visibleSlidesIndexes = [], t.visibleSlides = [];
                for (let e = 0; e < s.length; e += 1) {
                    const a = s[e];
                    let l = a.swiperSlideOffset;
                    n.cssMode && n.centeredSlides && (l -= s[0].swiperSlideOffset);
                    const c = (r + (n.centeredSlides ? t.minTranslate() : 0) - l) / (a.swiperSlideSize + n.spaceBetween),
                        d = (r - o[0] + (n.centeredSlides ? t.minTranslate() : 0) - l) / (a.swiperSlideSize + n.spaceBetween),
                        u = -(r - l),
                        p = u + t.slidesSizesGrid[e];
                    (u >= 0 && u < t.size - 1 || p > 1 && p <= t.size || u <= 0 && p >= t.size) && (t.visibleSlides.push(a), t.visibleSlidesIndexes.push(e), s.eq(e).addClass(n.slideVisibleClass)), a.progress = i ? -c : c, a.originalProgress = i ? -d : d
                }
                t.visibleSlides = m(t.visibleSlides)
            },
            updateProgress: function(e) {
                const t = this;
                if (void 0 === e) {
                    const n = t.rtlTranslate ? -1 : 1;
                    e = t && t.translate && t.translate * n || 0
                }
                const n = t.params,
                    s = t.maxTranslate() - t.minTranslate();
                let {
                    progress: i,
                    isBeginning: o,
                    isEnd: r
                } = t;
                const a = o,
                    l = r;
                0 === s ? (i = 0, o = !0, r = !0) : (i = (e - t.minTranslate()) / s, o = i <= 0, r = i >= 1), Object.assign(t, {
                    progress: i,
                    isBeginning: o,
                    isEnd: r
                }), (n.watchSlidesProgress || n.centeredSlides && n.autoHeight) && t.updateSlidesProgress(e), o && !a && t.emit("reachBeginning toEdge"), r && !l && t.emit("reachEnd toEdge"), (a && !o || l && !r) && t.emit("fromEdge"), t.emit("progress", i)
            },
            updateSlidesClasses: function() {
                const e = this,
                    {
                        slides: t,
                        params: n,
                        $wrapperEl: s,
                        activeIndex: i,
                        realIndex: o
                    } = e,
                    r = e.virtual && n.virtual.enabled;
                let a;
                t.removeClass(`${n.slideActiveClass} ${n.slideNextClass} ${n.slidePrevClass} ${n.slideDuplicateActiveClass} ${n.slideDuplicateNextClass} ${n.slideDuplicatePrevClass}`), a = r ? e.$wrapperEl.find(`.${n.slideClass}[data-swiper-slide-index="${i}"]`) : t.eq(i), a.addClass(n.slideActiveClass), n.loop && (a.hasClass(n.slideDuplicateClass) ? s.children(`.${n.slideClass}:not(.${n.slideDuplicateClass})[data-swiper-slide-index="${o}"]`).addClass(n.slideDuplicateActiveClass) : s.children(`.${n.slideClass}.${n.slideDuplicateClass}[data-swiper-slide-index="${o}"]`).addClass(n.slideDuplicateActiveClass));
                let l = a.nextAll(`.${n.slideClass}`).eq(0).addClass(n.slideNextClass);
                n.loop && 0 === l.length && (l = t.eq(0), l.addClass(n.slideNextClass));
                let c = a.prevAll(`.${n.slideClass}`).eq(0).addClass(n.slidePrevClass);
                n.loop && 0 === c.length && (c = t.eq(-1), c.addClass(n.slidePrevClass)), n.loop && (l.hasClass(n.slideDuplicateClass) ? s.children(`.${n.slideClass}:not(.${n.slideDuplicateClass})[data-swiper-slide-index="${l.attr("data-swiper-slide-index")}"]`).addClass(n.slideDuplicateNextClass) : s.children(`.${n.slideClass}.${n.slideDuplicateClass}[data-swiper-slide-index="${l.attr("data-swiper-slide-index")}"]`).addClass(n.slideDuplicateNextClass), c.hasClass(n.slideDuplicateClass) ? s.children(`.${n.slideClass}:not(.${n.slideDuplicateClass})[data-swiper-slide-index="${c.attr("data-swiper-slide-index")}"]`).addClass(n.slideDuplicatePrevClass) : s.children(`.${n.slideClass}.${n.slideDuplicateClass}[data-swiper-slide-index="${c.attr("data-swiper-slide-index")}"]`).addClass(n.slideDuplicatePrevClass)), e.emitSlidesClasses()
            },
            updateActiveIndex: function(e) {
                const t = this,
                    n = t.rtlTranslate ? t.translate : -t.translate,
                    {
                        slidesGrid: s,
                        snapGrid: i,
                        params: o,
                        activeIndex: r,
                        realIndex: a,
                        snapIndex: l
                    } = t;
                let c, d = e;
                if (void 0 === d) {
                    for (let e = 0; e < s.length; e += 1) void 0 !== s[e + 1] ? n >= s[e] && n < s[e + 1] - (s[e + 1] - s[e]) / 2 ? d = e : n >= s[e] && n < s[e + 1] && (d = e + 1) : n >= s[e] && (d = e);
                    o.normalizeSlideIndex && (d < 0 || void 0 === d) && (d = 0)
                }
                if (i.indexOf(n) >= 0) c = i.indexOf(n);
                else {
                    const e = Math.min(o.slidesPerGroupSkip, d);
                    c = e + Math.floor((d - e) / o.slidesPerGroup)
                }
                if (c >= i.length && (c = i.length - 1), d === r) return void(c !== l && (t.snapIndex = c, t.emit("snapIndexChange")));
                const u = parseInt(t.slides.eq(d).attr("data-swiper-slide-index") || d, 10);
                Object.assign(t, {
                    snapIndex: c,
                    realIndex: u,
                    previousIndex: r,
                    activeIndex: d
                }), t.emit("activeIndexChange"), t.emit("snapIndexChange"), a !== u && t.emit("realIndexChange"), (t.initialized || t.params.runCallbacksOnInit) && t.emit("slideChange")
            },
            updateClickedSlide: function(e) {
                const t = this,
                    n = t.params,
                    s = m(e.target).closest(`.${n.slideClass}`)[0];
                let i, o = !1;
                if (s)
                    for (let e = 0; e < t.slides.length; e += 1)
                        if (t.slides[e] === s) {
                            o = !0, i = e;
                            break
                        }
                if (!s || !o) return t.clickedSlide = void 0, void(t.clickedIndex = void 0);
                t.clickedSlide = s, t.virtual && t.params.virtual.enabled ? t.clickedIndex = parseInt(m(s).attr("data-swiper-slide-index"), 10) : t.clickedIndex = i, n.slideToClickedSlide && void 0 !== t.clickedIndex && t.clickedIndex !== t.activeIndex && t.slideToClickedSlide()
            }
        };
        const M = {
            getTranslate: function(e = (this.isHorizontal() ? "x" : "y")) {
                const {
                    params: t,
                    rtlTranslate: n,
                    translate: s,
                    $wrapperEl: i
                } = this;
                if (t.virtualTranslate) return n ? -s : s;
                if (t.cssMode) return s;
                let o = v(i[0], e);
                return n && (o = -o), o || 0
            },
            setTranslate: function(e, t) {
                const n = this,
                    {
                        rtlTranslate: s,
                        params: i,
                        $wrapperEl: o,
                        wrapperEl: r,
                        progress: a
                    } = n;
                let l, c = 0,
                    d = 0;
                n.isHorizontal() ? c = s ? -e : e : d = e, i.roundLengths && (c = Math.floor(c), d = Math.floor(d)), i.cssMode ? r[n.isHorizontal() ? "scrollLeft" : "scrollTop"] = n.isHorizontal() ? -c : -d : i.virtualTranslate || o.transform(`translate3d(${c}px, ${d}px, 0px)`), n.previousTranslate = n.translate, n.translate = n.isHorizontal() ? c : d;
                const u = n.maxTranslate() - n.minTranslate();
                l = 0 === u ? 0 : (e - n.minTranslate()) / u, l !== a && n.updateProgress(e), n.emit("setTranslate", n.translate, t)
            },
            minTranslate: function() {
                return -this.snapGrid[0]
            },
            maxTranslate: function() {
                return -this.snapGrid[this.snapGrid.length - 1]
            },
            translateTo: function(e = 0, t = this.params.speed, n = !0, s = !0, i) {
                const o = this,
                    {
                        params: r,
                        wrapperEl: a
                    } = o;
                if (o.animating && r.preventInteractionOnTransition) return !1;
                const l = o.minTranslate(),
                    c = o.maxTranslate();
                let d;
                if (d = s && e > l ? l : s && e < c ? c : e, o.updateProgress(d), r.cssMode) {
                    const e = o.isHorizontal();
                    if (0 === t) a[e ? "scrollLeft" : "scrollTop"] = -d;
                    else {
                        if (!o.support.smoothScroll) return C({
                            swiper: o,
                            targetPosition: -d,
                            side: e ? "right" : "top"
                        }), !0;
                        a.scrollTo({
                            [e ? "right" : "top"]: -d,
                            behavior: "smooth"
                        })
                    }
                    return !0
                }
                return 0 === t ? (o.setTransition(0), o.setTranslate(d), n && (o.emit("beforeTransitionStart", t, i), o.emit("transitionEnd"))) : (o.setTransition(t), o.setTranslate(d), n && (o.emit("beforeTransitionStart", t, i), o.emit("transitionStart")), o.animating || (o.animating = !0, o.onTranslateToWrapperTransitionEnd || (o.onTranslateToWrapperTransitionEnd = function(e) {
                    o && !o.destroyed && e.target === this && (o.$wrapperEl[0].removeEventListener("transitionend", o.onTranslateToWrapperTransitionEnd), o.$wrapperEl[0].removeEventListener("webkitTransitionEnd", o.onTranslateToWrapperTransitionEnd), o.onTranslateToWrapperTransitionEnd = null, delete o.onTranslateToWrapperTransitionEnd, n && o.emit("transitionEnd"))
                }), o.$wrapperEl[0].addEventListener("transitionend", o.onTranslateToWrapperTransitionEnd), o.$wrapperEl[0].addEventListener("webkitTransitionEnd", o.onTranslateToWrapperTransitionEnd))), !0
            }
        };

        function L({
            swiper: e,
            runCallbacks: t,
            direction: n,
            step: s
        }) {
            const {
                activeIndex: i,
                previousIndex: o
            } = e;
            let r = n;
            if (r || (r = i > o ? "next" : i < o ? "prev" : "reset"), e.emit(`transition${s}`), t && i !== o) {
                if ("reset" === r) return void e.emit(`slideResetTransition${s}`);
                e.emit(`slideChangeTransition${s}`), "next" === r ? e.emit(`slideNextTransition${s}`) : e.emit(`slidePrevTransition${s}`)
            }
        }
        const B = {
            slideTo: function(e = 0, t = this.params.speed, n = !0, s, i) {
                if ("number" != typeof e && "string" != typeof e) throw new Error(`The 'index' argument cannot have type other than 'number' or 'string'. [${typeof e}] given.`);
                if ("string" == typeof e) {
                    const t = parseInt(e, 10);
                    if (!isFinite(t)) throw new Error(`The passed-in 'index' (string) couldn't be converted to 'number'. [${e}] given.`);
                    e = t
                }
                const o = this;
                let r = e;
                r < 0 && (r = 0);
                const {
                    params: a,
                    snapGrid: l,
                    slidesGrid: c,
                    previousIndex: d,
                    activeIndex: u,
                    rtlTranslate: p,
                    wrapperEl: h,
                    enabled: m
                } = o;
                if (o.animating && a.preventInteractionOnTransition || !m && !s && !i) return !1;
                const f = Math.min(o.params.slidesPerGroupSkip, r);
                let g = f + Math.floor((r - f) / o.params.slidesPerGroup);
                g >= l.length && (g = l.length - 1), (u || a.initialSlide || 0) === (d || 0) && n && o.emit("beforeSlideChangeStart");
                const v = -l[g];
                if (o.updateProgress(v), a.normalizeSlideIndex)
                    for (let e = 0; e < c.length; e += 1) {
                        const t = -Math.floor(100 * v),
                            n = Math.floor(100 * c[e]),
                            s = Math.floor(100 * c[e + 1]);
                        void 0 !== c[e + 1] ? t >= n && t < s - (s - n) / 2 ? r = e : t >= n && t < s && (r = e + 1) : t >= n && (r = e)
                    }
                if (o.initialized && r !== u) {
                    if (!o.allowSlideNext && v < o.translate && v < o.minTranslate()) return !1;
                    if (!o.allowSlidePrev && v > o.translate && v > o.maxTranslate() && (u || 0) !== r) return !1
                }
                let b;
                if (b = r > u ? "next" : r < u ? "prev" : "reset", p && -v === o.translate || !p && v === o.translate) return o.updateActiveIndex(r), a.autoHeight && o.updateAutoHeight(), o.updateSlidesClasses(), "slide" !== a.effect && o.setTranslate(v), "reset" !== b && (o.transitionStart(n, b), o.transitionEnd(n, b)), !1;
                if (a.cssMode) {
                    const e = o.isHorizontal(),
                        n = p ? v : -v;
                    if (0 === t) {
                        const t = o.virtual && o.params.virtual.enabled;
                        t && (o.wrapperEl.style.scrollSnapType = "none", o._immediateVirtual = !0), h[e ? "scrollLeft" : "scrollTop"] = n, t && requestAnimationFrame((() => {
                            o.wrapperEl.style.scrollSnapType = "", o._swiperImmediateVirtual = !1
                        }))
                    } else {
                        if (!o.support.smoothScroll) return C({
                            swiper: o,
                            targetPosition: n,
                            side: e ? "right" : "top"
                        }), !0;
                        h.scrollTo({
                            [e ? "right" : "top"]: n,
                            behavior: "smooth"
                        })
                    }
                    return !0
                }
                return 0 === t ? (o.setTransition(0), o.setTranslate(v), o.updateActiveIndex(r), o.updateSlidesClasses(), o.emit("beforeTransitionStart", t, s), o.transitionStart(n, b), o.transitionEnd(n, b)) : (o.setTransition(t), o.setTranslate(v), o.updateActiveIndex(r), o.updateSlidesClasses(), o.emit("beforeTransitionStart", t, s), o.transitionStart(n, b), o.animating || (o.animating = !0, o.onSlideToWrapperTransitionEnd || (o.onSlideToWrapperTransitionEnd = function(e) {
                    o && !o.destroyed && e.target === this && (o.$wrapperEl[0].removeEventListener("transitionend", o.onSlideToWrapperTransitionEnd), o.$wrapperEl[0].removeEventListener("webkitTransitionEnd", o.onSlideToWrapperTransitionEnd), o.onSlideToWrapperTransitionEnd = null, delete o.onSlideToWrapperTransitionEnd, o.transitionEnd(n, b))
                }), o.$wrapperEl[0].addEventListener("transitionend", o.onSlideToWrapperTransitionEnd), o.$wrapperEl[0].addEventListener("webkitTransitionEnd", o.onSlideToWrapperTransitionEnd))), !0
            },
            slideToLoop: function(e = 0, t = this.params.speed, n = !0, s) {
                const i = this;
                let o = e;
                return i.params.loop && (o += i.loopedSlides), i.slideTo(o, t, n, s)
            },
            slideNext: function(e = this.params.speed, t = !0, n) {
                const s = this,
                    {
                        animating: i,
                        enabled: o,
                        params: r
                    } = s;
                if (!o) return s;
                let a = r.slidesPerGroup;
                "auto" === r.slidesPerView && 1 === r.slidesPerGroup && r.slidesPerGroupAuto && (a = Math.max(s.slidesPerViewDynamic("current", !0), 1));
                const l = s.activeIndex < r.slidesPerGroupSkip ? 1 : a;
                if (r.loop) {
                    if (i && r.loopPreventsSlide) return !1;
                    s.loopFix(), s._clientLeft = s.$wrapperEl[0].clientLeft
                }
                return s.slideTo(s.activeIndex + l, e, t, n)
            },
            slidePrev: function(e = this.params.speed, t = !0, n) {
                const s = this,
                    {
                        params: i,
                        animating: o,
                        snapGrid: r,
                        slidesGrid: a,
                        rtlTranslate: l,
                        enabled: c
                    } = s;
                if (!c) return s;
                if (i.loop) {
                    if (o && i.loopPreventsSlide) return !1;
                    s.loopFix(), s._clientLeft = s.$wrapperEl[0].clientLeft
                }

                function d(e) {
                    return e < 0 ? -Math.floor(Math.abs(e)) : Math.floor(e)
                }
                const u = d(l ? s.translate : -s.translate),
                    p = r.map((e => d(e)));
                let h = r[p.indexOf(u) - 1];
                if (void 0 === h && i.cssMode) {
                    let e;
                    r.forEach(((t, n) => {
                        u >= t && (e = n)
                    })), void 0 !== e && (h = r[e > 0 ? e - 1 : e])
                }
                let m = 0;
                return void 0 !== h && (m = a.indexOf(h), m < 0 && (m = s.activeIndex - 1), "auto" === i.slidesPerView && 1 === i.slidesPerGroup && i.slidesPerGroupAuto && (m = m - s.slidesPerViewDynamic("previous", !0) + 1, m = Math.max(m, 0))), s.slideTo(m, e, t, n)
            },
            slideReset: function(e = this.params.speed, t = !0, n) {
                return this.slideTo(this.activeIndex, e, t, n)
            },
            slideToClosest: function(e = this.params.speed, t = !0, n, s = .5) {
                const i = this;
                let o = i.activeIndex;
                const r = Math.min(i.params.slidesPerGroupSkip, o),
                    a = r + Math.floor((o - r) / i.params.slidesPerGroup),
                    l = i.rtlTranslate ? i.translate : -i.translate;
                if (l >= i.snapGrid[a]) {
                    const e = i.snapGrid[a];
                    l - e > (i.snapGrid[a + 1] - e) * s && (o += i.params.slidesPerGroup)
                } else {
                    const e = i.snapGrid[a - 1];
                    l - e <= (i.snapGrid[a] - e) * s && (o -= i.params.slidesPerGroup)
                }
                return o = Math.max(o, 0), o = Math.min(o, i.slidesGrid.length - 1), i.slideTo(o, e, t, n)
            },
            slideToClickedSlide: function() {
                const e = this,
                    {
                        params: t,
                        $wrapperEl: n
                    } = e,
                    s = "auto" === t.slidesPerView ? e.slidesPerViewDynamic() : t.slidesPerView;
                let i, o = e.clickedIndex;
                if (t.loop) {
                    if (e.animating) return;
                    i = parseInt(m(e.clickedSlide).attr("data-swiper-slide-index"), 10), t.centeredSlides ? o < e.loopedSlides - s / 2 || o > e.slides.length - e.loopedSlides + s / 2 ? (e.loopFix(), o = n.children(`.${t.slideClass}[data-swiper-slide-index="${i}"]:not(.${t.slideDuplicateClass})`).eq(0).index(), f((() => {
                        e.slideTo(o)
                    }))) : e.slideTo(o) : o > e.slides.length - s ? (e.loopFix(), o = n.children(`.${t.slideClass}[data-swiper-slide-index="${i}"]:not(.${t.slideDuplicateClass})`).eq(0).index(), f((() => {
                        e.slideTo(o)
                    }))) : e.slideTo(o)
                } else e.slideTo(o)
            }
        };
        const $ = {
            loopCreate: function() {
                const e = this,
                    t = i(),
                    {
                        params: n,
                        $wrapperEl: s
                    } = e,
                    o = m(s.children()[0].parentNode);
                o.children(`.${n.slideClass}.${n.slideDuplicateClass}`).remove();
                let r = o.children(`.${n.slideClass}`);
                if (n.loopFillGroupWithBlank) {
                    const e = n.slidesPerGroup - r.length % n.slidesPerGroup;
                    if (e !== n.slidesPerGroup) {
                        for (let s = 0; s < e; s += 1) {
                            const e = m(t.createElement("div")).addClass(`${n.slideClass} ${n.slideBlankClass}`);
                            o.append(e)
                        }
                        r = o.children(`.${n.slideClass}`)
                    }
                }
                "auto" !== n.slidesPerView || n.loopedSlides || (n.loopedSlides = r.length), e.loopedSlides = Math.ceil(parseFloat(n.loopedSlides || n.slidesPerView, 10)), e.loopedSlides += n.loopAdditionalSlides, e.loopedSlides > r.length && (e.loopedSlides = r.length);
                const a = [],
                    l = [];
                r.each(((t, n) => {
                    const s = m(t);
                    n < e.loopedSlides && l.push(t), n < r.length && n >= r.length - e.loopedSlides && a.push(t), s.attr("data-swiper-slide-index", n)
                }));
                for (let e = 0; e < l.length; e += 1) o.append(m(l[e].cloneNode(!0)).addClass(n.slideDuplicateClass));
                for (let e = a.length - 1; e >= 0; e -= 1) o.prepend(m(a[e].cloneNode(!0)).addClass(n.slideDuplicateClass))
            },
            loopFix: function() {
                const e = this;
                e.emit("beforeLoopFix");
                const {
                    activeIndex: t,
                    slides: n,
                    loopedSlides: s,
                    allowSlidePrev: i,
                    allowSlideNext: o,
                    snapGrid: r,
                    rtlTranslate: a
                } = e;
                let l;
                e.allowSlidePrev = !0, e.allowSlideNext = !0;
                const c = -r[t] - e.getTranslate();
                if (t < s) {
                    l = n.length - 3 * s + t, l += s;
                    e.slideTo(l, 0, !1, !0) && 0 !== c && e.setTranslate((a ? -e.translate : e.translate) - c)
                } else if (t >= n.length - s) {
                    l = -n.length + t + s, l += s;
                    e.slideTo(l, 0, !1, !0) && 0 !== c && e.setTranslate((a ? -e.translate : e.translate) - c)
                }
                e.allowSlidePrev = i, e.allowSlideNext = o, e.emit("loopFix")
            },
            loopDestroy: function() {
                const {
                    $wrapperEl: e,
                    params: t,
                    slides: n
                } = this;
                e.children(`.${t.slideClass}.${t.slideDuplicateClass},.${t.slideClass}.${t.slideBlankClass}`).remove(), n.removeAttr("data-swiper-slide-index")
            }
        };

        function I(e) {
            const t = this,
                n = i(),
                s = r(),
                o = t.touchEventsData,
                {
                    params: a,
                    touches: l,
                    enabled: c
                } = t;
            if (!c) return;
            if (t.animating && a.preventInteractionOnTransition) return;
            !t.animating && a.cssMode && a.loop && t.loopFix();
            let d = e;
            d.originalEvent && (d = d.originalEvent);
            let u = m(d.target);
            if ("wrapper" === a.touchEventsTarget && !u.closest(t.wrapperEl).length) return;
            if (o.isTouchEvent = "touchstart" === d.type, !o.isTouchEvent && "which" in d && 3 === d.which) return;
            if (!o.isTouchEvent && "button" in d && d.button > 0) return;
            if (o.isTouched && o.isMoved) return;
            !!a.noSwipingClass && "" !== a.noSwipingClass && d.target && d.target.shadowRoot && e.path && e.path[0] && (u = m(e.path[0]));
            const p = a.noSwipingSelector ? a.noSwipingSelector : `.${a.noSwipingClass}`,
                h = !(!d.target || !d.target.shadowRoot);
            if (a.noSwiping && (h ? function(e, t = this) {
                    return function t(n) {
                        return n && n !== i() && n !== r() ? (n.assignedSlot && (n = n.assignedSlot), n.closest(e) || t(n.getRootNode().host)) : null
                    }(t)
                }(p, d.target) : u.closest(p)[0])) return void(t.allowClick = !0);
            if (a.swipeHandler && !u.closest(a.swipeHandler)[0]) return;
            l.currentX = "touchstart" === d.type ? d.targetTouches[0].pageX : d.pageX, l.currentY = "touchstart" === d.type ? d.targetTouches[0].pageY : d.pageY;
            const f = l.currentX,
                v = l.currentY,
                b = a.edgeSwipeDetection || a.iOSEdgeSwipeDetection,
                w = a.edgeSwipeThreshold || a.iOSEdgeSwipeThreshold;
            if (b && (f <= w || f >= s.innerWidth - w)) {
                if ("prevent" !== b) return;
                e.preventDefault()
            }
            if (Object.assign(o, {
                    isTouched: !0,
                    isMoved: !1,
                    allowTouchCallbacks: !0,
                    isScrolling: void 0,
                    startMoving: void 0
                }), l.startX = f, l.startY = v, o.touchStartTime = g(), t.allowClick = !0, t.updateSize(), t.swipeDirection = void 0, a.threshold > 0 && (o.allowThresholdMove = !1), "touchstart" !== d.type) {
                let e = !0;
                u.is(o.focusableElements) && (e = !1), n.activeElement && m(n.activeElement).is(o.focusableElements) && n.activeElement !== u[0] && n.activeElement.blur();
                const s = e && t.allowTouchMove && a.touchStartPreventDefault;
                !a.touchStartForcePreventDefault && !s || u[0].isContentEditable || d.preventDefault()
            }
            t.emit("touchStart", d)
        }

        function D(e) {
            const t = i(),
                n = this,
                s = n.touchEventsData,
                {
                    params: o,
                    touches: r,
                    rtlTranslate: a,
                    enabled: l
                } = n;
            if (!l) return;
            let c = e;
            if (c.originalEvent && (c = c.originalEvent), !s.isTouched) return void(s.startMoving && s.isScrolling && n.emit("touchMoveOpposite", c));
            if (s.isTouchEvent && "touchmove" !== c.type) return;
            const d = "touchmove" === c.type && c.targetTouches && (c.targetTouches[0] || c.changedTouches[0]),
                u = "touchmove" === c.type ? d.pageX : c.pageX,
                p = "touchmove" === c.type ? d.pageY : c.pageY;
            if (c.preventedByNestedSwiper) return r.startX = u, void(r.startY = p);
            if (!n.allowTouchMove) return n.allowClick = !1, void(s.isTouched && (Object.assign(r, {
                startX: u,
                startY: p,
                currentX: u,
                currentY: p
            }), s.touchStartTime = g()));
            if (s.isTouchEvent && o.touchReleaseOnEdges && !o.loop)
                if (n.isVertical()) {
                    if (p < r.startY && n.translate <= n.maxTranslate() || p > r.startY && n.translate >= n.minTranslate()) return s.isTouched = !1, void(s.isMoved = !1)
                } else if (u < r.startX && n.translate <= n.maxTranslate() || u > r.startX && n.translate >= n.minTranslate()) return;
            if (s.isTouchEvent && t.activeElement && c.target === t.activeElement && m(c.target).is(s.focusableElements)) return s.isMoved = !0, void(n.allowClick = !1);
            if (s.allowTouchCallbacks && n.emit("touchMove", c), c.targetTouches && c.targetTouches.length > 1) return;
            r.currentX = u, r.currentY = p;
            const h = r.currentX - r.startX,
                f = r.currentY - r.startY;
            if (n.params.threshold && Math.sqrt(h ** 2 + f ** 2) < n.params.threshold) return;
            if (void 0 === s.isScrolling) {
                let e;
                n.isHorizontal() && r.currentY === r.startY || n.isVertical() && r.currentX === r.startX ? s.isScrolling = !1 : h * h + f * f >= 25 && (e = 180 * Math.atan2(Math.abs(f), Math.abs(h)) / Math.PI, s.isScrolling = n.isHorizontal() ? e > o.touchAngle : 90 - e > o.touchAngle)
            }
            if (s.isScrolling && n.emit("touchMoveOpposite", c), void 0 === s.startMoving && (r.currentX === r.startX && r.currentY === r.startY || (s.startMoving = !0)), s.isScrolling) return void(s.isTouched = !1);
            if (!s.startMoving) return;
            n.allowClick = !1, !o.cssMode && c.cancelable && c.preventDefault(), o.touchMoveStopPropagation && !o.nested && c.stopPropagation(), s.isMoved || (o.loop && !o.cssMode && n.loopFix(), s.startTranslate = n.getTranslate(), n.setTransition(0), n.animating && n.$wrapperEl.trigger("webkitTransitionEnd transitionend"), s.allowMomentumBounce = !1, !o.grabCursor || !0 !== n.allowSlideNext && !0 !== n.allowSlidePrev || n.setGrabCursor(!0), n.emit("sliderFirstMove", c)), n.emit("sliderMove", c), s.isMoved = !0;
            let v = n.isHorizontal() ? h : f;
            r.diff = v, v *= o.touchRatio, a && (v = -v), n.swipeDirection = v > 0 ? "prev" : "next", s.currentTranslate = v + s.startTranslate;
            let b = !0,
                w = o.resistanceRatio;
            if (o.touchReleaseOnEdges && (w = 0), v > 0 && s.currentTranslate > n.minTranslate() ? (b = !1, o.resistance && (s.currentTranslate = n.minTranslate() - 1 + (-n.minTranslate() + s.startTranslate + v) ** w)) : v < 0 && s.currentTranslate < n.maxTranslate() && (b = !1, o.resistance && (s.currentTranslate = n.maxTranslate() + 1 - (n.maxTranslate() - s.startTranslate - v) ** w)), b && (c.preventedByNestedSwiper = !0), !n.allowSlideNext && "next" === n.swipeDirection && s.currentTranslate < s.startTranslate && (s.currentTranslate = s.startTranslate), !n.allowSlidePrev && "prev" === n.swipeDirection && s.currentTranslate > s.startTranslate && (s.currentTranslate = s.startTranslate), n.allowSlidePrev || n.allowSlideNext || (s.currentTranslate = s.startTranslate), o.threshold > 0) {
                if (!(Math.abs(v) > o.threshold || s.allowThresholdMove)) return void(s.currentTranslate = s.startTranslate);
                if (!s.allowThresholdMove) return s.allowThresholdMove = !0, r.startX = r.currentX, r.startY = r.currentY, s.currentTranslate = s.startTranslate, void(r.diff = n.isHorizontal() ? r.currentX - r.startX : r.currentY - r.startY)
            }
            o.followFinger && !o.cssMode && ((o.freeMode && o.freeMode.enabled && n.freeMode || o.watchSlidesProgress) && (n.updateActiveIndex(), n.updateSlidesClasses()), n.params.freeMode && o.freeMode.enabled && n.freeMode && n.freeMode.onTouchMove(), n.updateProgress(s.currentTranslate), n.setTranslate(s.currentTranslate))
        }

        function j(e) {
            const t = this,
                n = t.touchEventsData,
                {
                    params: s,
                    touches: i,
                    rtlTranslate: o,
                    slidesGrid: r,
                    enabled: a
                } = t;
            if (!a) return;
            let l = e;
            if (l.originalEvent && (l = l.originalEvent), n.allowTouchCallbacks && t.emit("touchEnd", l), n.allowTouchCallbacks = !1, !n.isTouched) return n.isMoved && s.grabCursor && t.setGrabCursor(!1), n.isMoved = !1, void(n.startMoving = !1);
            s.grabCursor && n.isMoved && n.isTouched && (!0 === t.allowSlideNext || !0 === t.allowSlidePrev) && t.setGrabCursor(!1);
            const c = g(),
                d = c - n.touchStartTime;
            if (t.allowClick && (t.updateClickedSlide(l), t.emit("tap click", l), d < 300 && c - n.lastClickTime < 300 && t.emit("doubleTap doubleClick", l)), n.lastClickTime = g(), f((() => {
                    t.destroyed || (t.allowClick = !0)
                })), !n.isTouched || !n.isMoved || !t.swipeDirection || 0 === i.diff || n.currentTranslate === n.startTranslate) return n.isTouched = !1, n.isMoved = !1, void(n.startMoving = !1);
            let u;
            if (n.isTouched = !1, n.isMoved = !1, n.startMoving = !1, u = s.followFinger ? o ? t.translate : -t.translate : -n.currentTranslate, s.cssMode) return;
            if (t.params.freeMode && s.freeMode.enabled) return void t.freeMode.onTouchEnd({
                currentPos: u
            });
            let p = 0,
                h = t.slidesSizesGrid[0];
            for (let e = 0; e < r.length; e += e < s.slidesPerGroupSkip ? 1 : s.slidesPerGroup) {
                const t = e < s.slidesPerGroupSkip - 1 ? 1 : s.slidesPerGroup;
                void 0 !== r[e + t] ? u >= r[e] && u < r[e + t] && (p = e, h = r[e + t] - r[e]) : u >= r[e] && (p = e, h = r[r.length - 1] - r[r.length - 2])
            }
            const m = (u - r[p]) / h,
                v = p < s.slidesPerGroupSkip - 1 ? 1 : s.slidesPerGroup;
            if (d > s.longSwipesMs) {
                if (!s.longSwipes) return void t.slideTo(t.activeIndex);
                "next" === t.swipeDirection && (m >= s.longSwipesRatio ? t.slideTo(p + v) : t.slideTo(p)), "prev" === t.swipeDirection && (m > 1 - s.longSwipesRatio ? t.slideTo(p + v) : t.slideTo(p))
            } else {
                if (!s.shortSwipes) return void t.slideTo(t.activeIndex);
                t.navigation && (l.target === t.navigation.nextEl || l.target === t.navigation.prevEl) ? l.target === t.navigation.nextEl ? t.slideTo(p + v) : t.slideTo(p) : ("next" === t.swipeDirection && t.slideTo(p + v), "prev" === t.swipeDirection && t.slideTo(p))
            }
        }

        function z() {
            const e = this,
                {
                    params: t,
                    el: n
                } = e;
            if (n && 0 === n.offsetWidth) return;
            t.breakpoints && e.setBreakpoint();
            const {
                allowSlideNext: s,
                allowSlidePrev: i,
                snapGrid: o
            } = e;
            e.allowSlideNext = !0, e.allowSlidePrev = !0, e.updateSize(), e.updateSlides(), e.updateSlidesClasses(), ("auto" === t.slidesPerView || t.slidesPerView > 1) && e.isEnd && !e.isBeginning && !e.params.centeredSlides ? e.slideTo(e.slides.length - 1, 0, !1, !0) : e.slideTo(e.activeIndex, 0, !1, !0), e.autoplay && e.autoplay.running && e.autoplay.paused && e.autoplay.run(), e.allowSlidePrev = i, e.allowSlideNext = s, e.params.watchOverflow && o !== e.snapGrid && e.checkOverflow()
        }

        function N(e) {
            const t = this;
            t.enabled && (t.allowClick || (t.params.preventClicks && e.preventDefault(), t.params.preventClicksPropagation && t.animating && (e.stopPropagation(), e.stopImmediatePropagation())))
        }

        function H() {
            const e = this,
                {
                    wrapperEl: t,
                    rtlTranslate: n,
                    enabled: s
                } = e;
            if (!s) return;
            let i;
            e.previousTranslate = e.translate, e.isHorizontal() ? e.translate = -t.scrollLeft : e.translate = -t.scrollTop, -0 === e.translate && (e.translate = 0), e.updateActiveIndex(), e.updateSlidesClasses();
            const o = e.maxTranslate() - e.minTranslate();
            i = 0 === o ? 0 : (e.translate - e.minTranslate()) / o, i !== e.progress && e.updateProgress(n ? -e.translate : e.translate), e.emit("setTranslate", e.translate, !1)
        }
        let _ = !1;

        function G() {}
        const V = (e, t) => {
            const n = i(),
                {
                    params: s,
                    touchEvents: o,
                    el: r,
                    wrapperEl: a,
                    device: l,
                    support: c
                } = e,
                d = !!s.nested,
                u = "on" === t ? "addEventListener" : "removeEventListener",
                p = t;
            if (c.touch) {
                const t = !("touchstart" !== o.start || !c.passiveListener || !s.passiveListeners) && {
                    passive: !0,
                    capture: !1
                };
                r[u](o.start, e.onTouchStart, t), r[u](o.move, e.onTouchMove, c.passiveListener ? {
                    passive: !1,
                    capture: d
                } : d), r[u](o.end, e.onTouchEnd, t), o.cancel && r[u](o.cancel, e.onTouchEnd, t)
            } else r[u](o.start, e.onTouchStart, !1), n[u](o.move, e.onTouchMove, d), n[u](o.end, e.onTouchEnd, !1);
            (s.preventClicks || s.preventClicksPropagation) && r[u]("click", e.onClick, !0), s.cssMode && a[u]("scroll", e.onScroll), s.updateOnWindowResize ? e[p](l.ios || l.android ? "resize orientationchange observerUpdate" : "resize observerUpdate", z, !0) : e[p]("observerUpdate", z, !0)
        };
        const q = {
                attachEvents: function() {
                    const e = this,
                        t = i(),
                        {
                            params: n,
                            support: s
                        } = e;
                    e.onTouchStart = I.bind(e), e.onTouchMove = D.bind(e), e.onTouchEnd = j.bind(e), n.cssMode && (e.onScroll = H.bind(e)), e.onClick = N.bind(e), s.touch && !_ && (t.addEventListener("touchstart", G), _ = !0), V(e, "on")
                },
                detachEvents: function() {
                    V(this, "off")
                }
            },
            F = (e, t) => e.grid && t.grid && t.grid.rows > 1;
        const R = {
            setBreakpoint: function() {
                const e = this,
                    {
                        activeIndex: t,
                        initialized: n,
                        loopedSlides: s = 0,
                        params: i,
                        $el: o
                    } = e,
                    r = i.breakpoints;
                if (!r || r && 0 === Object.keys(r).length) return;
                const a = e.getBreakpoint(r, e.params.breakpointsBase, e.el);
                if (!a || e.currentBreakpoint === a) return;
                const l = (a in r ? r[a] : void 0) || e.originalParams,
                    c = F(e, i),
                    d = F(e, l),
                    u = i.enabled;
                c && !d ? (o.removeClass(`${i.containerModifierClass}grid ${i.containerModifierClass}grid-column`), e.emitContainerClasses()) : !c && d && (o.addClass(`${i.containerModifierClass}grid`), (l.grid.fill && "column" === l.grid.fill || !l.grid.fill && "column" === i.grid.fill) && o.addClass(`${i.containerModifierClass}grid-column`), e.emitContainerClasses());
                const p = l.direction && l.direction !== i.direction,
                    h = i.loop && (l.slidesPerView !== i.slidesPerView || p);
                p && n && e.changeDirection(), w(e.params, l);
                const m = e.params.enabled;
                Object.assign(e, {
                    allowTouchMove: e.params.allowTouchMove,
                    allowSlideNext: e.params.allowSlideNext,
                    allowSlidePrev: e.params.allowSlidePrev
                }), u && !m ? e.disable() : !u && m && e.enable(), e.currentBreakpoint = a, e.emit("_beforeBreakpoint", l), h && n && (e.loopDestroy(), e.loopCreate(), e.updateSlides(), e.slideTo(t - s + e.loopedSlides, 0, !1)), e.emit("breakpoint", l)
            },
            getBreakpoint: function(e, t = "window", n) {
                if (!e || "container" === t && !n) return;
                let s = !1;
                const i = r(),
                    o = "window" === t ? i.innerHeight : n.clientHeight,
                    a = Object.keys(e).map((e => {
                        if ("string" == typeof e && 0 === e.indexOf("@")) {
                            const t = parseFloat(e.substr(1));
                            return {
                                value: o * t,
                                point: e
                            }
                        }
                        return {
                            value: e,
                            point: e
                        }
                    }));
                a.sort(((e, t) => parseInt(e.value, 10) - parseInt(t.value, 10)));
                for (let e = 0; e < a.length; e += 1) {
                    const {
                        point: o,
                        value: r
                    } = a[e];
                    "window" === t ? i.matchMedia(`(min-width: ${r}px)`).matches && (s = o) : r <= n.clientWidth && (s = o)
                }
                return s || "max"
            }
        };
        const W = {
            addClasses: function() {
                const e = this,
                    {
                        classNames: t,
                        params: n,
                        rtl: s,
                        $el: i,
                        device: o,
                        support: r
                    } = e,
                    a = function(e, t) {
                        const n = [];
                        return e.forEach((e => {
                            "object" == typeof e ? Object.keys(e).forEach((s => {
                                e[s] && n.push(t + s)
                            })) : "string" == typeof e && n.push(t + e)
                        })), n
                    }(["initialized", n.direction, {
                        "pointer-events": !r.touch
                    }, {
                        "free-mode": e.params.freeMode && n.freeMode.enabled
                    }, {
                        autoheight: n.autoHeight
                    }, {
                        rtl: s
                    }, {
                        grid: n.grid && n.grid.rows > 1
                    }, {
                        "grid-column": n.grid && n.grid.rows > 1 && "column" === n.grid.fill
                    }, {
                        android: o.android
                    }, {
                        ios: o.ios
                    }, {
                        "css-mode": n.cssMode
                    }, {
                        centered: n.cssMode && n.centeredSlides
                    }], n.containerModifierClass);
                t.push(...a), i.addClass([...t].join(" ")), e.emitContainerClasses()
            },
            removeClasses: function() {
                const {
                    $el: e,
                    classNames: t
                } = this;
                e.removeClass(t.join(" ")), this.emitContainerClasses()
            }
        };
        const Y = {
            init: !0,
            direction: "horizontal",
            touchEventsTarget: "wrapper",
            initialSlide: 0,
            speed: 300,
            cssMode: !1,
            updateOnWindowResize: !0,
            resizeObserver: !0,
            nested: !1,
            createElements: !1,
            enabled: !0,
            focusableElements: "input, select, option, textarea, button, video, label",
            width: null,
            height: null,
            preventInteractionOnTransition: !1,
            userAgent: null,
            url: null,
            edgeSwipeDetection: !1,
            edgeSwipeThreshold: 20,
            autoHeight: !1,
            setWrapperSize: !1,
            virtualTranslate: !1,
            effect: "slide",
            breakpoints: void 0,
            breakpointsBase: "window",
            spaceBetween: 0,
            slidesPerView: 1,
            slidesPerGroup: 1,
            slidesPerGroupSkip: 0,
            slidesPerGroupAuto: !1,
            centeredSlides: !1,
            centeredSlidesBounds: !1,
            slidesOffsetBefore: 0,
            slidesOffsetAfter: 0,
            normalizeSlideIndex: !0,
            centerInsufficientSlides: !1,
            watchOverflow: !0,
            roundLengths: !1,
            touchRatio: 1,
            touchAngle: 45,
            simulateTouch: !0,
            shortSwipes: !0,
            longSwipes: !0,
            longSwipesRatio: .5,
            longSwipesMs: 300,
            followFinger: !0,
            allowTouchMove: !0,
            threshold: 0,
            touchMoveStopPropagation: !1,
            touchStartPreventDefault: !0,
            touchStartForcePreventDefault: !1,
            touchReleaseOnEdges: !1,
            uniqueNavElements: !0,
            resistance: !0,
            resistanceRatio: .85,
            watchSlidesProgress: !1,
            grabCursor: !1,
            preventClicks: !0,
            preventClicksPropagation: !0,
            slideToClickedSlide: !1,
            preloadImages: !0,
            updateOnImagesReady: !0,
            loop: !1,
            loopAdditionalSlides: 0,
            loopedSlides: null,
            loopFillGroupWithBlank: !1,
            loopPreventsSlide: !0,
            allowSlidePrev: !0,
            allowSlideNext: !0,
            swipeHandler: null,
            noSwiping: !0,
            noSwipingClass: "swiper-no-swiping",
            noSwipingSelector: null,
            passiveListeners: !0,
            containerModifierClass: "swiper-",
            slideClass: "swiper-slide",
            slideBlankClass: "swiper-slide-invisible-blank",
            slideActiveClass: "swiper-slide-active",
            slideDuplicateActiveClass: "swiper-slide-duplicate-active",
            slideVisibleClass: "swiper-slide-visible",
            slideDuplicateClass: "swiper-slide-duplicate",
            slideNextClass: "swiper-slide-next",
            slideDuplicateNextClass: "swiper-slide-duplicate-next",
            slidePrevClass: "swiper-slide-prev",
            slideDuplicatePrevClass: "swiper-slide-duplicate-prev",
            wrapperClass: "swiper-wrapper",
            runCallbacksOnInit: !0,
            _emitClasses: !1
        };

        function U(e, t) {
            return function(n = {}) {
                const s = Object.keys(n)[0],
                    i = n[s];
                "object" == typeof i && null !== i ? (["navigation", "pagination", "scrollbar"].indexOf(s) >= 0 && !0 === e[s] && (e[s] = {
                    auto: !0
                }), s in e && "enabled" in i ? (!0 === e[s] && (e[s] = {
                    enabled: !0
                }), "object" != typeof e[s] || "enabled" in e[s] || (e[s].enabled = !0), e[s] || (e[s] = {
                    enabled: !1
                }), w(t, n)) : w(t, n)) : w(t, n)
            }
        }
        const X = {
                eventsEmitter: O,
                update: A,
                translate: M,
                transition: {
                    setTransition: function(e, t) {
                        const n = this;
                        n.params.cssMode || n.$wrapperEl.transition(e), n.emit("setTransition", e, t)
                    },
                    transitionStart: function(e = !0, t) {
                        const n = this,
                            {
                                params: s
                            } = n;
                        s.cssMode || (s.autoHeight && n.updateAutoHeight(), L({
                            swiper: n,
                            runCallbacks: e,
                            direction: t,
                            step: "Start"
                        }))
                    },
                    transitionEnd: function(e = !0, t) {
                        const n = this,
                            {
                                params: s
                            } = n;
                        n.animating = !1, s.cssMode || (n.setTransition(0), L({
                            swiper: n,
                            runCallbacks: e,
                            direction: t,
                            step: "End"
                        }))
                    }
                },
                slide: B,
                loop: $,
                grabCursor: {
                    setGrabCursor: function(e) {
                        const t = this;
                        if (t.support.touch || !t.params.simulateTouch || t.params.watchOverflow && t.isLocked || t.params.cssMode) return;
                        const n = "container" === t.params.touchEventsTarget ? t.el : t.wrapperEl;
                        n.style.cursor = "move", n.style.cursor = e ? "-webkit-grabbing" : "-webkit-grab", n.style.cursor = e ? "-moz-grabbin" : "-moz-grab", n.style.cursor = e ? "grabbing" : "grab"
                    },
                    unsetGrabCursor: function() {
                        const e = this;
                        e.support.touch || e.params.watchOverflow && e.isLocked || e.params.cssMode || (e["container" === e.params.touchEventsTarget ? "el" : "wrapperEl"].style.cursor = "")
                    }
                },
                events: q,
                breakpoints: R,
                checkOverflow: {
                    checkOverflow: function() {
                        const e = this,
                            {
                                isLocked: t,
                                params: n
                            } = e,
                            {
                                slidesOffsetBefore: s
                            } = n;
                        if (s) {
                            const t = e.slides.length - 1,
                                n = e.slidesGrid[t] + e.slidesSizesGrid[t] + 2 * s;
                            e.isLocked = e.size > n
                        } else e.isLocked = 1 === e.snapGrid.length;
                        !0 === n.allowSlideNext && (e.allowSlideNext = !e.isLocked), !0 === n.allowSlidePrev && (e.allowSlidePrev = !e.isLocked), t && t !== e.isLocked && (e.isEnd = !1), t !== e.isLocked && e.emit(e.isLocked ? "lock" : "unlock")
                    }
                },
                classes: W,
                images: {
                    loadImage: function(e, t, n, s, i, o) {
                        const a = r();
                        let l;

                        function c() {
                            o && o()
                        }
                        m(e).parent("picture")[0] || e.complete && i ? c() : t ? (l = new a.Image, l.onload = c, l.onerror = c, s && (l.sizes = s), n && (l.srcset = n), t && (l.src = t)) : c()
                    },
                    preloadImages: function() {
                        const e = this;

                        function t() {
                            null != e && e && !e.destroyed && (void 0 !== e.imagesLoaded && (e.imagesLoaded += 1), e.imagesLoaded === e.imagesToLoad.length && (e.params.updateOnImagesReady && e.update(), e.emit("imagesReady")))
                        }
                        e.imagesToLoad = e.$el.find("img");
                        for (let n = 0; n < e.imagesToLoad.length; n += 1) {
                            const s = e.imagesToLoad[n];
                            e.loadImage(s, s.currentSrc || s.getAttribute("src"), s.srcset || s.getAttribute("srcset"), s.sizes || s.getAttribute("sizes"), !0, t)
                        }
                    }
                }
            },
            K = {};
        class Z {
            constructor(...e) {
                let t, n;
                if (1 === e.length && e[0].constructor && "Object" === Object.prototype.toString.call(e[0]).slice(8, -1) ? n = e[0] : [t, n] = e, n || (n = {}), n = w({}, n), t && !n.el && (n.el = t), n.el && m(n.el).length > 1) {
                    const e = [];
                    return m(n.el).each((t => {
                        const s = w({}, n, {
                            el: t
                        });
                        e.push(new Z(s))
                    })), e
                }
                const s = this;
                s.__swiper__ = !0, s.support = E(), s.device = k({
                    userAgent: n.userAgent
                }), s.browser = P(), s.eventsListeners = {}, s.eventsAnyListeners = [], s.modules = [...s.__modules__], n.modules && Array.isArray(n.modules) && s.modules.push(...n.modules);
                const i = {};
                s.modules.forEach((e => {
                    e({
                        swiper: s,
                        extendParams: U(n, i),
                        on: s.on.bind(s),
                        once: s.once.bind(s),
                        off: s.off.bind(s),
                        emit: s.emit.bind(s)
                    })
                }));
                const o = w({}, Y, i);
                return s.params = w({}, o, K, n), s.originalParams = w({}, s.params), s.passedParams = w({}, n), s.params && s.params.on && Object.keys(s.params.on).forEach((e => {
                    s.on(e, s.params.on[e])
                })), s.params && s.params.onAny && s.onAny(s.params.onAny), s.$ = m, Object.assign(s, {
                    enabled: s.params.enabled,
                    el: t,
                    classNames: [],
                    slides: m(),
                    slidesGrid: [],
                    snapGrid: [],
                    slidesSizesGrid: [],
                    isHorizontal: () => "horizontal" === s.params.direction,
                    isVertical: () => "vertical" === s.params.direction,
                    activeIndex: 0,
                    realIndex: 0,
                    isBeginning: !0,
                    isEnd: !1,
                    translate: 0,
                    previousTranslate: 0,
                    progress: 0,
                    velocity: 0,
                    animating: !1,
                    allowSlideNext: s.params.allowSlideNext,
                    allowSlidePrev: s.params.allowSlidePrev,
                    touchEvents: function() {
                        const e = ["touchstart", "touchmove", "touchend", "touchcancel"],
                            t = ["pointerdown", "pointermove", "pointerup"];
                        return s.touchEventsTouch = {
                            start: e[0],
                            move: e[1],
                            end: e[2],
                            cancel: e[3]
                        }, s.touchEventsDesktop = {
                            start: t[0],
                            move: t[1],
                            end: t[2]
                        }, s.support.touch || !s.params.simulateTouch ? s.touchEventsTouch : s.touchEventsDesktop
                    }(),
                    touchEventsData: {
                        isTouched: void 0,
                        isMoved: void 0,
                        allowTouchCallbacks: void 0,
                        touchStartTime: void 0,
                        isScrolling: void 0,
                        currentTranslate: void 0,
                        startTranslate: void 0,
                        allowThresholdMove: void 0,
                        focusableElements: s.params.focusableElements,
                        lastClickTime: g(),
                        clickTimeout: void 0,
                        velocities: [],
                        allowMomentumBounce: void 0,
                        isTouchEvent: void 0,
                        startMoving: void 0
                    },
                    allowClick: !0,
                    allowTouchMove: s.params.allowTouchMove,
                    touches: {
                        startX: 0,
                        startY: 0,
                        currentX: 0,
                        currentY: 0,
                        diff: 0
                    },
                    imagesToLoad: [],
                    imagesLoaded: 0
                }), s.emit("_swiper"), s.params.init && s.init(), s
            }
            enable() {
                const e = this;
                e.enabled || (e.enabled = !0, e.params.grabCursor && e.setGrabCursor(), e.emit("enable"))
            }
            disable() {
                const e = this;
                e.enabled && (e.enabled = !1, e.params.grabCursor && e.unsetGrabCursor(), e.emit("disable"))
            }
            setProgress(e, t) {
                const n = this;
                e = Math.min(Math.max(e, 0), 1);
                const s = n.minTranslate(),
                    i = (n.maxTranslate() - s) * e + s;
                n.translateTo(i, void 0 === t ? 0 : t), n.updateActiveIndex(), n.updateSlidesClasses()
            }
            emitContainerClasses() {
                const e = this;
                if (!e.params._emitClasses || !e.el) return;
                const t = e.el.className.split(" ").filter((t => 0 === t.indexOf("swiper") || 0 === t.indexOf(e.params.containerModifierClass)));
                e.emit("_containerClasses", t.join(" "))
            }
            getSlideClasses(e) {
                const t = this;
                return e.className.split(" ").filter((e => 0 === e.indexOf("swiper-slide") || 0 === e.indexOf(t.params.slideClass))).join(" ")
            }
            emitSlidesClasses() {
                const e = this;
                if (!e.params._emitClasses || !e.el) return;
                const t = [];
                e.slides.each((n => {
                    const s = e.getSlideClasses(n);
                    t.push({
                        slideEl: n,
                        classNames: s
                    }), e.emit("_slideClass", n, s)
                })), e.emit("_slideClasses", t)
            }
            slidesPerViewDynamic(e = "current", t = !1) {
                const {
                    params: n,
                    slides: s,
                    slidesGrid: i,
                    slidesSizesGrid: o,
                    size: r,
                    activeIndex: a
                } = this;
                let l = 1;
                if (n.centeredSlides) {
                    let e, t = s[a].swiperSlideSize;
                    for (let n = a + 1; n < s.length; n += 1) s[n] && !e && (t += s[n].swiperSlideSize, l += 1, t > r && (e = !0));
                    for (let n = a - 1; n >= 0; n -= 1) s[n] && !e && (t += s[n].swiperSlideSize, l += 1, t > r && (e = !0))
                } else if ("current" === e)
                    for (let e = a + 1; e < s.length; e += 1) {
                        (t ? i[e] + o[e] - i[a] < r : i[e] - i[a] < r) && (l += 1)
                    } else
                        for (let e = a - 1; e >= 0; e -= 1) {
                            i[a] - i[e] < r && (l += 1)
                        }
                return l
            }
            update() {
                const e = this;
                if (!e || e.destroyed) return;
                const {
                    snapGrid: t,
                    params: n
                } = e;

                function s() {
                    const t = e.rtlTranslate ? -1 * e.translate : e.translate,
                        n = Math.min(Math.max(t, e.maxTranslate()), e.minTranslate());
                    e.setTranslate(n), e.updateActiveIndex(), e.updateSlidesClasses()
                }
                let i;
                n.breakpoints && e.setBreakpoint(), e.updateSize(), e.updateSlides(), e.updateProgress(), e.updateSlidesClasses(), e.params.freeMode && e.params.freeMode.enabled ? (s(), e.params.autoHeight && e.updateAutoHeight()) : (i = ("auto" === e.params.slidesPerView || e.params.slidesPerView > 1) && e.isEnd && !e.params.centeredSlides ? e.slideTo(e.slides.length - 1, 0, !1, !0) : e.slideTo(e.activeIndex, 0, !1, !0), i || s()), n.watchOverflow && t !== e.snapGrid && e.checkOverflow(), e.emit("update")
            }
            changeDirection(e, t = !0) {
                const n = this,
                    s = n.params.direction;
                return e || (e = "horizontal" === s ? "vertical" : "horizontal"), e === s || "horizontal" !== e && "vertical" !== e || (n.$el.removeClass(`${n.params.containerModifierClass}${s}`).addClass(`${n.params.containerModifierClass}${e}`), n.emitContainerClasses(), n.params.direction = e, n.slides.each((t => {
                    "vertical" === e ? t.style.width = "" : t.style.height = ""
                })), n.emit("changeDirection"), t && n.update()), n
            }
            mount(e) {
                const t = this;
                if (t.mounted) return !0;
                const n = m(e || t.params.el);
                if (!(e = n[0])) return !1;
                e.swiper = t;
                const s = () => `.${(t.params.wrapperClass||"").trim().split(" ").join(".")}`;
                let o = (() => {
                    if (e && e.shadowRoot && e.shadowRoot.querySelector) {
                        const t = m(e.shadowRoot.querySelector(s()));
                        return t.children = e => n.children(e), t
                    }
                    return n.children(s())
                })();
                if (0 === o.length && t.params.createElements) {
                    const e = i().createElement("div");
                    o = m(e), e.className = t.params.wrapperClass, n.append(e), n.children(`.${t.params.slideClass}`).each((e => {
                        o.append(e)
                    }))
                }
                return Object.assign(t, {
                    $el: n,
                    el: e,
                    $wrapperEl: o,
                    wrapperEl: o[0],
                    mounted: !0,
                    rtl: "rtl" === e.dir.toLowerCase() || "rtl" === n.css("direction"),
                    rtlTranslate: "horizontal" === t.params.direction && ("rtl" === e.dir.toLowerCase() || "rtl" === n.css("direction")),
                    wrongRTL: "-webkit-box" === o.css("display")
                }), !0
            }
            init(e) {
                const t = this;
                if (t.initialized) return t;
                return !1 === t.mount(e) || (t.emit("beforeInit"), t.params.breakpoints && t.setBreakpoint(), t.addClasses(), t.params.loop && t.loopCreate(), t.updateSize(), t.updateSlides(), t.params.watchOverflow && t.checkOverflow(), t.params.grabCursor && t.enabled && t.setGrabCursor(), t.params.preloadImages && t.preloadImages(), t.params.loop ? t.slideTo(t.params.initialSlide + t.loopedSlides, 0, t.params.runCallbacksOnInit, !1, !0) : t.slideTo(t.params.initialSlide, 0, t.params.runCallbacksOnInit, !1, !0), t.attachEvents(), t.initialized = !0, t.emit("init"), t.emit("afterInit")), t
            }
            destroy(e = !0, t = !0) {
                const n = this,
                    {
                        params: s,
                        $el: i,
                        $wrapperEl: o,
                        slides: r
                    } = n;
                return void 0 === n.params || n.destroyed || (n.emit("beforeDestroy"), n.initialized = !1, n.detachEvents(), s.loop && n.loopDestroy(), t && (n.removeClasses(), i.removeAttr("style"), o.removeAttr("style"), r && r.length && r.removeClass([s.slideVisibleClass, s.slideActiveClass, s.slideNextClass, s.slidePrevClass].join(" ")).removeAttr("style").removeAttr("data-swiper-slide-index")), n.emit("destroy"), Object.keys(n.eventsListeners).forEach((e => {
                    n.off(e)
                })), !1 !== e && (n.$el[0].swiper = null, function(e) {
                    const t = e;
                    Object.keys(t).forEach((e => {
                        try {
                            t[e] = null
                        } catch (e) {}
                        try {
                            delete t[e]
                        } catch (e) {}
                    }))
                }(n)), n.destroyed = !0), null
            }
            static extendDefaults(e) {
                w(K, e)
            }
            static get extendedDefaults() {
                return K
            }
            static get defaults() {
                return Y
            }
            static installModule(e) {
                Z.prototype.__modules__ || (Z.prototype.__modules__ = []);
                const t = Z.prototype.__modules__;
                "function" == typeof e && t.indexOf(e) < 0 && t.push(e)
            }
            static use(e) {
                return Array.isArray(e) ? (e.forEach((e => Z.installModule(e))), Z) : (Z.installModule(e), Z)
            }
        }
        Object.keys(X).forEach((e => {
            Object.keys(X[e]).forEach((t => {
                Z.prototype[t] = X[e][t]
            }))
        })), Z.use([function({
            swiper: e,
            on: t,
            emit: n
        }) {
            const s = r();
            let i = null;
            const o = () => {
                    e && !e.destroyed && e.initialized && (n("beforeResize"), n("resize"))
                },
                a = () => {
                    e && !e.destroyed && e.initialized && n("orientationchange")
                };
            t("init", (() => {
                e.params.resizeObserver && void 0 !== s.ResizeObserver ? e && !e.destroyed && e.initialized && (i = new ResizeObserver((t => {
                    const {
                        width: n,
                        height: s
                    } = e;
                    let i = n,
                        r = s;
                    t.forEach((({
                        contentBoxSize: t,
                        contentRect: n,
                        target: s
                    }) => {
                        s && s !== e.el || (i = n ? n.width : (t[0] || t).inlineSize, r = n ? n.height : (t[0] || t).blockSize)
                    })), i === n && r === s || o()
                })), i.observe(e.el)) : (s.addEventListener("resize", o), s.addEventListener("orientationchange", a))
            })), t("destroy", (() => {
                i && i.unobserve && e.el && (i.unobserve(e.el), i = null), s.removeEventListener("resize", o), s.removeEventListener("orientationchange", a)
            }))
        }, function({
            swiper: e,
            extendParams: t,
            on: n,
            emit: s
        }) {
            const i = [],
                o = r(),
                a = (e, t = {}) => {
                    const n = new(o.MutationObserver || o.WebkitMutationObserver)((e => {
                        if (1 === e.length) return void s("observerUpdate", e[0]);
                        const t = function() {
                            s("observerUpdate", e[0])
                        };
                        o.requestAnimationFrame ? o.requestAnimationFrame(t) : o.setTimeout(t, 0)
                    }));
                    n.observe(e, {
                        attributes: void 0 === t.attributes || t.attributes,
                        childList: void 0 === t.childList || t.childList,
                        characterData: void 0 === t.characterData || t.characterData
                    }), i.push(n)
                };
            t({
                observer: !1,
                observeParents: !1,
                observeSlideChildren: !1
            }), n("init", (() => {
                if (e.params.observer) {
                    if (e.params.observeParents) {
                        const t = e.$el.parents();
                        for (let e = 0; e < t.length; e += 1) a(t[e])
                    }
                    a(e.$el[0], {
                        childList: e.params.observeSlideChildren
                    }), a(e.$wrapperEl[0], {
                        attributes: !1
                    })
                }
            })), n("destroy", (() => {
                i.forEach((e => {
                    e.disconnect()
                })), i.splice(0, i.length)
            }))
        }]);
        const J = Z;

        function Q(e, t, n, s) {
            const o = i();
            return e.params.createElements && Object.keys(s).forEach((i => {
                if (!n[i] && !0 === n.auto) {
                    let r = e.$el.children(`.${s[i]}`)[0];
                    r || (r = o.createElement("div"), r.className = s[i], e.$el.append(r)), n[i] = r, t[i] = r
                }
            })), n
        }

        function ee(e = "") {
            return `.${e.trim().replace(/([\.:!\/])/g,"\\$1").replace(/ /g,".")}`
        }

        function te(e, t) {
            var n = Object.keys(e);
            if (Object.getOwnPropertySymbols) {
                var s = Object.getOwnPropertySymbols(e);
                t && (s = s.filter((function(t) {
                    return Object.getOwnPropertyDescriptor(e, t).enumerable
                }))), n.push.apply(n, s)
            }
            return n
        }

        function ne(e) {
            for (var t = 1; t < arguments.length; t++) {
                var n = null != arguments[t] ? arguments[t] : {};
                t % 2 ? te(Object(n), !0).forEach((function(t) {
                    se(e, t, n[t])
                })) : Object.getOwnPropertyDescriptors ? Object.defineProperties(e, Object.getOwnPropertyDescriptors(n)) : te(Object(n)).forEach((function(t) {
                    Object.defineProperty(e, t, Object.getOwnPropertyDescriptor(n, t))
                }))
            }
            return e
        }

        function se(e, t, n) {
            return t in e ? Object.defineProperty(e, t, {
                value: n,
                enumerable: !0,
                configurable: !0,
                writable: !0
            }) : e[t] = n, e
        }
        J.use([function({
            swiper: e,
            extendParams: t,
            on: n,
            emit: s
        }) {
            function i(t) {
                let n;
                return t && (n = m(t), e.params.uniqueNavElements && "string" == typeof t && n.length > 1 && 1 === e.$el.find(t).length && (n = e.$el.find(t))), n
            }

            function o(t, n) {
                const s = e.params.navigation;
                t && t.length > 0 && (t[n ? "addClass" : "removeClass"](s.disabledClass), t[0] && "BUTTON" === t[0].tagName && (t[0].disabled = n), e.params.watchOverflow && e.enabled && t[e.isLocked ? "addClass" : "removeClass"](s.lockClass))
            }

            function r() {
                if (e.params.loop) return;
                const {
                    $nextEl: t,
                    $prevEl: n
                } = e.navigation;
                o(n, e.isBeginning), o(t, e.isEnd)
            }

            function a(t) {
                t.preventDefault(), e.isBeginning && !e.params.loop || e.slidePrev()
            }

            function l(t) {
                t.preventDefault(), e.isEnd && !e.params.loop || e.slideNext()
            }

            function c() {
                const t = e.params.navigation;
                if (e.params.navigation = Q(e, e.originalParams.navigation, e.params.navigation, {
                        nextEl: "swiper-button-next",
                        prevEl: "swiper-button-prev"
                    }), !t.nextEl && !t.prevEl) return;
                const n = i(t.nextEl),
                    s = i(t.prevEl);
                n && n.length > 0 && n.on("click", l), s && s.length > 0 && s.on("click", a), Object.assign(e.navigation, {
                    $nextEl: n,
                    nextEl: n && n[0],
                    $prevEl: s,
                    prevEl: s && s[0]
                }), e.enabled || (n && n.addClass(t.lockClass), s && s.addClass(t.lockClass))
            }

            function d() {
                const {
                    $nextEl: t,
                    $prevEl: n
                } = e.navigation;
                t && t.length && (t.off("click", l), t.removeClass(e.params.navigation.disabledClass)), n && n.length && (n.off("click", a), n.removeClass(e.params.navigation.disabledClass))
            }
            t({
                navigation: {
                    nextEl: null,
                    prevEl: null,
                    hideOnClick: !1,
                    disabledClass: "swiper-button-disabled",
                    hiddenClass: "swiper-button-hidden",
                    lockClass: "swiper-button-lock"
                }
            }), e.navigation = {
                nextEl: null,
                $nextEl: null,
                prevEl: null,
                $prevEl: null
            }, n("init", (() => {
                c(), r()
            })), n("toEdge fromEdge lock unlock", (() => {
                r()
            })), n("destroy", (() => {
                d()
            })), n("enable disable", (() => {
                const {
                    $nextEl: t,
                    $prevEl: n
                } = e.navigation;
                t && t[e.enabled ? "removeClass" : "addClass"](e.params.navigation.lockClass), n && n[e.enabled ? "removeClass" : "addClass"](e.params.navigation.lockClass)
            })), n("click", ((t, n) => {
                const {
                    $nextEl: i,
                    $prevEl: o
                } = e.navigation, r = n.target;
                if (e.params.navigation.hideOnClick && !m(r).is(o) && !m(r).is(i)) {
                    if (e.pagination && e.params.pagination && e.params.pagination.clickable && (e.pagination.el === r || e.pagination.el.contains(r))) return;
                    let t;
                    i ? t = i.hasClass(e.params.navigation.hiddenClass) : o && (t = o.hasClass(e.params.navigation.hiddenClass)), s(!0 === t ? "navigationShow" : "navigationHide"), i && i.toggleClass(e.params.navigation.hiddenClass), o && o.toggleClass(e.params.navigation.hiddenClass)
                }
            })), Object.assign(e.navigation, {
                update: r,
                init: c,
                destroy: d
            })
        }, function({
            swiper: e,
            extendParams: t,
            on: n,
            emit: s
        }) {
            const i = "swiper-pagination";
            let o;
            t({
                pagination: {
                    el: null,
                    bulletElement: "span",
                    clickable: !1,
                    hideOnClick: !1,
                    renderBullet: null,
                    renderProgressbar: null,
                    renderFraction: null,
                    renderCustom: null,
                    progressbarOpposite: !1,
                    type: "bullets",
                    dynamicBullets: !1,
                    dynamicMainBullets: 1,
                    formatFractionCurrent: e => e,
                    formatFractionTotal: e => e,
                    bulletClass: `${i}-bullet`,
                    bulletActiveClass: `${i}-bullet-active`,
                    modifierClass: `${i}-`,
                    currentClass: `${i}-current`,
                    totalClass: `${i}-total`,
                    hiddenClass: `${i}-hidden`,
                    progressbarFillClass: `${i}-progressbar-fill`,
                    progressbarOppositeClass: `${i}-progressbar-opposite`,
                    clickableClass: `${i}-clickable`,
                    lockClass: `${i}-lock`,
                    horizontalClass: `${i}-horizontal`,
                    verticalClass: `${i}-vertical`
                }
            }), e.pagination = {
                el: null,
                $el: null,
                bullets: []
            };
            let r = 0;

            function a() {
                return !e.params.pagination.el || !e.pagination.el || !e.pagination.$el || 0 === e.pagination.$el.length
            }

            function l(t, n) {
                const {
                    bulletActiveClass: s
                } = e.params.pagination;
                t[n]().addClass(`${s}-${n}`)[n]().addClass(`${s}-${n}-${n}`)
            }

            function c() {
                const t = e.rtl,
                    n = e.params.pagination;
                if (a()) return;
                const i = e.virtual && e.params.virtual.enabled ? e.virtual.slides.length : e.slides.length,
                    c = e.pagination.$el;
                let d;
                const u = e.params.loop ? Math.ceil((i - 2 * e.loopedSlides) / e.params.slidesPerGroup) : e.snapGrid.length;
                if (e.params.loop ? (d = Math.ceil((e.activeIndex - e.loopedSlides) / e.params.slidesPerGroup), d > i - 1 - 2 * e.loopedSlides && (d -= i - 2 * e.loopedSlides), d > u - 1 && (d -= u), d < 0 && "bullets" !== e.params.paginationType && (d = u + d)) : d = void 0 !== e.snapIndex ? e.snapIndex : e.activeIndex || 0, "bullets" === n.type && e.pagination.bullets && e.pagination.bullets.length > 0) {
                    const s = e.pagination.bullets;
                    let i, a, u;
                    if (n.dynamicBullets && (o = s.eq(0)[e.isHorizontal() ? "outerWidth" : "outerHeight"](!0), c.css(e.isHorizontal() ? "width" : "height", o * (n.dynamicMainBullets + 4) + "px"), n.dynamicMainBullets > 1 && void 0 !== e.previousIndex && (r += d - e.previousIndex, r > n.dynamicMainBullets - 1 ? r = n.dynamicMainBullets - 1 : r < 0 && (r = 0)), i = d - r, a = i + (Math.min(s.length, n.dynamicMainBullets) - 1), u = (a + i) / 2), s.removeClass(["", "-next", "-next-next", "-prev", "-prev-prev", "-main"].map((e => `${n.bulletActiveClass}${e}`)).join(" ")), c.length > 1) s.each((e => {
                        const t = m(e),
                            s = t.index();
                        s === d && t.addClass(n.bulletActiveClass), n.dynamicBullets && (s >= i && s <= a && t.addClass(`${n.bulletActiveClass}-main`), s === i && l(t, "prev"), s === a && l(t, "next"))
                    }));
                    else {
                        const t = s.eq(d),
                            o = t.index();
                        if (t.addClass(n.bulletActiveClass), n.dynamicBullets) {
                            const t = s.eq(i),
                                r = s.eq(a);
                            for (let e = i; e <= a; e += 1) s.eq(e).addClass(`${n.bulletActiveClass}-main`);
                            if (e.params.loop)
                                if (o >= s.length - n.dynamicMainBullets) {
                                    for (let e = n.dynamicMainBullets; e >= 0; e -= 1) s.eq(s.length - e).addClass(`${n.bulletActiveClass}-main`);
                                    s.eq(s.length - n.dynamicMainBullets - 1).addClass(`${n.bulletActiveClass}-prev`)
                                } else l(t, "prev"), l(r, "next");
                            else l(t, "prev"), l(r, "next")
                        }
                    }
                    if (n.dynamicBullets) {
                        const i = Math.min(s.length, n.dynamicMainBullets + 4),
                            r = (o * i - o) / 2 - u * o,
                            a = t ? "right" : "left";
                        s.css(e.isHorizontal() ? a : "top", `${r}px`)
                    }
                }
                if ("fraction" === n.type && (c.find(ee(n.currentClass)).text(n.formatFractionCurrent(d + 1)), c.find(ee(n.totalClass)).text(n.formatFractionTotal(u))), "progressbar" === n.type) {
                    let t;
                    t = n.progressbarOpposite ? e.isHorizontal() ? "vertical" : "horizontal" : e.isHorizontal() ? "horizontal" : "vertical";
                    const s = (d + 1) / u;
                    let i = 1,
                        o = 1;
                    "horizontal" === t ? i = s : o = s, c.find(ee(n.progressbarFillClass)).transform(`translate3d(0,0,0) scaleX(${i}) scaleY(${o})`).transition(e.params.speed)
                }
                "custom" === n.type && n.renderCustom ? (c.html(n.renderCustom(e, d + 1, u)), s("paginationRender", c[0])) : s("paginationUpdate", c[0]), e.params.watchOverflow && e.enabled && c[e.isLocked ? "addClass" : "removeClass"](n.lockClass)
            }

            function d() {
                const t = e.params.pagination;
                if (a()) return;
                const n = e.virtual && e.params.virtual.enabled ? e.virtual.slides.length : e.slides.length,
                    i = e.pagination.$el;
                let o = "";
                if ("bullets" === t.type) {
                    let s = e.params.loop ? Math.ceil((n - 2 * e.loopedSlides) / e.params.slidesPerGroup) : e.snapGrid.length;
                    e.params.freeMode && e.params.freeMode.enabled && !e.params.loop && s > n && (s = n);
                    for (let n = 0; n < s; n += 1) t.renderBullet ? o += t.renderBullet.call(e, n, t.bulletClass) : o += `<${t.bulletElement} class="${t.bulletClass}"></${t.bulletElement}>`;
                    i.html(o), e.pagination.bullets = i.find(ee(t.bulletClass))
                }
                "fraction" === t.type && (o = t.renderFraction ? t.renderFraction.call(e, t.currentClass, t.totalClass) : `<span class="${t.currentClass}"></span> / <span class="${t.totalClass}"></span>`, i.html(o)), "progressbar" === t.type && (o = t.renderProgressbar ? t.renderProgressbar.call(e, t.progressbarFillClass) : `<span class="${t.progressbarFillClass}"></span>`, i.html(o)), "custom" !== t.type && s("paginationRender", e.pagination.$el[0])
            }

            function u() {
                e.params.pagination = Q(e, e.originalParams.pagination, e.params.pagination, {
                    el: "swiper-pagination"
                });
                const t = e.params.pagination;
                if (!t.el) return;
                let n = m(t.el);
                0 !== n.length && (e.params.uniqueNavElements && "string" == typeof t.el && n.length > 1 && (n = e.$el.find(t.el), n.length > 1 && (n = n.filter((t => m(t).parents(".swiper")[0] === e.el)))), "bullets" === t.type && t.clickable && n.addClass(t.clickableClass), n.addClass(t.modifierClass + t.type), n.addClass(t.modifierClass + e.params.direction), "bullets" === t.type && t.dynamicBullets && (n.addClass(`${t.modifierClass}${t.type}-dynamic`), r = 0, t.dynamicMainBullets < 1 && (t.dynamicMainBullets = 1)), "progressbar" === t.type && t.progressbarOpposite && n.addClass(t.progressbarOppositeClass), t.clickable && n.on("click", ee(t.bulletClass), (function(t) {
                    t.preventDefault();
                    let n = m(this).index() * e.params.slidesPerGroup;
                    e.params.loop && (n += e.loopedSlides), e.slideTo(n)
                })), Object.assign(e.pagination, {
                    $el: n,
                    el: n[0]
                }), e.enabled || n.addClass(t.lockClass))
            }

            function p() {
                const t = e.params.pagination;
                if (a()) return;
                const n = e.pagination.$el;
                n.removeClass(t.hiddenClass), n.removeClass(t.modifierClass + t.type), n.removeClass(t.modifierClass + e.params.direction), e.pagination.bullets && e.pagination.bullets.removeClass && e.pagination.bullets.removeClass(t.bulletActiveClass), t.clickable && n.off("click", ee(t.bulletClass))
            }
            n("init", (() => {
                u(), d(), c()
            })), n("activeIndexChange", (() => {
                (e.params.loop || void 0 === e.snapIndex) && c()
            })), n("snapIndexChange", (() => {
                e.params.loop || c()
            })), n("slidesLengthChange", (() => {
                e.params.loop && (d(), c())
            })), n("snapGridLengthChange", (() => {
                e.params.loop || (d(), c())
            })), n("destroy", (() => {
                p()
            })), n("enable disable", (() => {
                const {
                    $el: t
                } = e.pagination;
                t && t[e.enabled ? "removeClass" : "addClass"](e.params.pagination.lockClass)
            })), n("lock unlock", (() => {
                c()
            })), n("click", ((t, n) => {
                const i = n.target,
                    {
                        $el: o
                    } = e.pagination;
                if (e.params.pagination.el && e.params.pagination.hideOnClick && o.length > 0 && !m(i).hasClass(e.params.pagination.bulletClass)) {
                    if (e.navigation && (e.navigation.nextEl && i === e.navigation.nextEl || e.navigation.prevEl && i === e.navigation.prevEl)) return;
                    const t = o.hasClass(e.params.pagination.hiddenClass);
                    s(!0 === t ? "paginationShow" : "paginationHide"), o.toggleClass(e.params.pagination.hiddenClass)
                }
            })), Object.assign(e.pagination, {
                render: d,
                update: c,
                init: u,
                destroy: p
            })
        }, function({
            swiper: e,
            extendParams: t,
            on: n,
            emit: s
        }) {
            let o;

            function r() {
                const t = e.slides.eq(e.activeIndex);
                let n = e.params.autoplay.delay;
                t.attr("data-swiper-autoplay") && (n = t.attr("data-swiper-autoplay") || e.params.autoplay.delay), clearTimeout(o), o = f((() => {
                    let t;
                    e.params.autoplay.reverseDirection ? e.params.loop ? (e.loopFix(), t = e.slidePrev(e.params.speed, !0, !0), s("autoplay")) : e.isBeginning ? e.params.autoplay.stopOnLastSlide ? l() : (t = e.slideTo(e.slides.length - 1, e.params.speed, !0, !0), s("autoplay")) : (t = e.slidePrev(e.params.speed, !0, !0), s("autoplay")) : e.params.loop ? (e.loopFix(), t = e.slideNext(e.params.speed, !0, !0), s("autoplay")) : e.isEnd ? e.params.autoplay.stopOnLastSlide ? l() : (t = e.slideTo(0, e.params.speed, !0, !0), s("autoplay")) : (t = e.slideNext(e.params.speed, !0, !0), s("autoplay")), (e.params.cssMode && e.autoplay.running || !1 === t) && r()
                }), n)
            }

            function a() {
                return void 0 === o && (!e.autoplay.running && (e.autoplay.running = !0, s("autoplayStart"), r(), !0))
            }

            function l() {
                return !!e.autoplay.running && (void 0 !== o && (o && (clearTimeout(o), o = void 0), e.autoplay.running = !1, s("autoplayStop"), !0))
            }

            function c(t) {
                e.autoplay.running && (e.autoplay.paused || (o && clearTimeout(o), e.autoplay.paused = !0, 0 !== t && e.params.autoplay.waitForTransition ? ["transitionend", "webkitTransitionEnd"].forEach((t => {
                    e.$wrapperEl[0].addEventListener(t, u)
                })) : (e.autoplay.paused = !1, r())))
            }

            function d() {
                const t = i();
                "hidden" === t.visibilityState && e.autoplay.running && c(), "visible" === t.visibilityState && e.autoplay.paused && (r(), e.autoplay.paused = !1)
            }

            function u(t) {
                e && !e.destroyed && e.$wrapperEl && t.target === e.$wrapperEl[0] && (["transitionend", "webkitTransitionEnd"].forEach((t => {
                    e.$wrapperEl[0].removeEventListener(t, u)
                })), e.autoplay.paused = !1, e.autoplay.running ? r() : l())
            }

            function p() {
                e.params.autoplay.disableOnInteraction ? l() : c(), ["transitionend", "webkitTransitionEnd"].forEach((t => {
                    e.$wrapperEl[0].removeEventListener(t, u)
                }))
            }

            function h() {
                e.params.autoplay.disableOnInteraction || (e.autoplay.paused = !1, r())
            }
            e.autoplay = {
                running: !1,
                paused: !1
            }, t({
                autoplay: {
                    enabled: !1,
                    delay: 3e3,
                    waitForTransition: !0,
                    disableOnInteraction: !0,
                    stopOnLastSlide: !1,
                    reverseDirection: !1,
                    pauseOnMouseEnter: !1
                }
            }), n("init", (() => {
                if (e.params.autoplay.enabled) {
                    a();
                    i().addEventListener("visibilitychange", d), e.params.autoplay.pauseOnMouseEnter && (e.$el.on("mouseenter", p), e.$el.on("mouseleave", h))
                }
            })), n("beforeTransitionStart", ((t, n, s) => {
                e.autoplay.running && (s || !e.params.autoplay.disableOnInteraction ? e.autoplay.pause(n) : l())
            })), n("sliderFirstMove", (() => {
                e.autoplay.running && (e.params.autoplay.disableOnInteraction ? l() : c())
            })), n("touchEnd", (() => {
                e.params.cssMode && e.autoplay.paused && !e.params.autoplay.disableOnInteraction && r()
            })), n("destroy", (() => {
                e.$el.off("mouseenter", p), e.$el.off("mouseleave", h), e.autoplay.running && l();
                i().removeEventListener("visibilitychange", d)
            })), Object.assign(e.autoplay, {
                pause: c,
                run: r,
                start: a,
                stop: l
            })
        }]);
        var ie = n(764),
            oe = n.n(ie);

        function re(e, t) {
            var n = Object.keys(e);
            if (Object.getOwnPropertySymbols) {
                var s = Object.getOwnPropertySymbols(e);
                t && (s = s.filter((function(t) {
                    return Object.getOwnPropertyDescriptor(e, t).enumerable
                }))), n.push.apply(n, s)
            }
            return n
        }

        function ae(e, t, n) {
            return t in e ? Object.defineProperty(e, t, {
                value: n,
                enumerable: !0,
                configurable: !0,
                writable: !0
            }) : e[t] = n, e
        }
        const le = function(e, t) {
            oe().fire(function(e) {
                for (var t = 1; t < arguments.length; t++) {
                    var n = null != arguments[t] ? arguments[t] : {};
                    t % 2 ? re(Object(n), !0).forEach((function(t) {
                        ae(e, t, n[t])
                    })) : Object.getOwnPropertyDescriptors ? Object.defineProperties(e, Object.getOwnPropertyDescriptors(n)) : re(Object(n)).forEach((function(t) {
                        Object.defineProperty(e, t, Object.getOwnPropertyDescriptor(n, t))
                    }))
                }
                return e
            }({
                showClass: {
                    popup: "fadeIn"
                },
                hideClass: {
                    popup: "fadeOut"
                },
                showConfirmButton: !1,
                showCloseButton: !0,
                closeButtonHtml: '\n                <i class="icon-close"></i>\n            ',
                html: '\n            <p class="main">'.concat(t || "", "</p>")
            }, e))
        };
        var ce = !1;

        function de() {
            window.pageYOffset > 1e3 && !ce && (le({
                title: "دوست خود را بیاورید و کارت تخفیف 10 درصدی دریافت کنید.",
                showCloseButton: !0,
                closeButtonHtml: '\n                <i class="icon-close"></i>\n            ',
                html: '\n                    <p class="main text">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ.\n                        <span class="linebreak">چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز.</span>\n                    </p>\n                    <a class="btn theme-element" href="#">اکنون رزرو کنید</a>\n                ',
                customClass: {
                    popup: "promo_popup",
                    title: "promo_popup-title",
                    htmlContainer: "promo_popup-content",
                    closeButton: "promo_popup-close",
                    container: "promo_popup-container"
                }
            }), ce = !0)
        }
        document.addEventListener("DOMContentLoaded", (function() {
            window.addEventListener("scroll", de),
                function(e, t, n) {
                    var s = new J(t, ne({}, n)),
                        i = document.querySelector(e),
                        o = document.querySelectorAll("".concat(t, " .swiper-slide"));

                    function r() {
                        var e = o[s.activeIndex].dataset.bg;
                        i.style.backgroundImage = 'url("'.concat(e, '")')
                    }
                    s.on("activeIndexChange", (function() {
                        r()
                    })), r()
                }(".hero", ".hero_slider", {
                    direction: "horizontal",
                    loop: !0,
                    speed: 1e3,
                    slidesPerView: 1,
                    pagination: {
                        el: ".swiper-pagination",
                        type: "progressbar"
                    },
                    navigation: {
                        nextEl: ".hero_slider-control--next",
                        prevEl: ".hero_slider-control--prev"
                    },
                    autoplay: {
                        delay: 5e3
                    }
                })
        }))
    })()
})();