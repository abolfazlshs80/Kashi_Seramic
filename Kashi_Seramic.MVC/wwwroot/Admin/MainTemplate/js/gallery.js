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
    var t = {
            731: function(t, e, n) {
                var i, o;
                /*!
                 * baguetteBox.js
                 * @author  feimosi
                 * @version 1.11.1
                 * @url https://github.com/feimosi/baguetteBox.js
                 */
                ! function(s, r) {
                    "use strict";
                    i = function() {
                        var t, e, n, i, o, s = '<svg width="44" height="60"><polyline points="30 10 10 30 30 50" stroke="rgba(255,255,255,0.5)" stroke-width="4"stroke-linecap="butt" fill="none" stroke-linejoin="round"/></svg>',
                            r = '<svg width="44" height="60"><polyline points="14 10 34 30 14 50" stroke="rgba(255,255,255,0.5)" stroke-width="4"stroke-linecap="butt" fill="none" stroke-linejoin="round"/></svg>',
                            a = '<svg width="30" height="30"><g stroke="rgb(160,160,160)" stroke-width="4"><line x1="5" y1="5" x2="25" y2="25"/><line x1="5" y1="25" x2="25" y2="5"/></g></svg>',
                            l = {},
                            u = {
                                captions: !0,
                                buttons: "auto",
                                fullScreen: !1,
                                noScrollbars: !1,
                                bodyClass: "baguetteBox-open",
                                titleTag: !1,
                                async: !1,
                                preload: 2,
                                animation: "slideIn",
                                afterShow: null,
                                afterHide: null,
                                onChange: null,
                                overlayBackgroundColor: "rgba(0,0,0,.8)"
                            },
                            c = {},
                            h = [],
                            f = 0,
                            d = !1,
                            p = {},
                            m = !1,
                            v = /.+\.(gif|jpe?g|png|webp)/i,
                            y = {},
                            g = [],
                            b = null,
                            _ = function(t) {
                                -1 !== t.target.id.indexOf("baguette-img") && P()
                            },
                            E = function(t) {
                                t.stopPropagation ? t.stopPropagation() : t.cancelBubble = !0, B()
                            },
                            w = function(t) {
                                t.stopPropagation ? t.stopPropagation() : t.cancelBubble = !0, z()
                            },
                            k = function(t) {
                                t.stopPropagation ? t.stopPropagation() : t.cancelBubble = !0, P()
                            },
                            I = function(t) {
                                p.count++, 1 < p.count && (p.multitouch = !0), p.startX = t.changedTouches[0].pageX, p.startY = t.changedTouches[0].pageY
                            },
                            T = function(t) {
                                if (!m && !p.multitouch) {
                                    t.preventDefault ? t.preventDefault() : t.returnValue = !1;
                                    var e = t.touches[0] || t.changedTouches[0];
                                    40 < e.pageX - p.startX ? (m = !0, B()) : e.pageX - p.startX < -40 ? (m = !0, z()) : 100 < p.startY - e.pageY && P()
                                }
                            },
                            S = function() {
                                p.count--, p.count <= 0 && (p.multitouch = !1), m = !1
                            },
                            C = function() {
                                S()
                            },
                            L = function(e) {
                                "block" === t.style.display && t.contains && !t.contains(e.target) && (e.stopPropagation(), M())
                            };

                        function O(t) {
                            if (y.hasOwnProperty(t)) {
                                var e = y[t].galleries;
                                [].forEach.call(e, (function(t) {
                                    [].forEach.call(t, (function(t) {
                                        W(t.imageElement, "click", t.eventHandler)
                                    })), h === t && (h = [])
                                })), delete y[t]
                            }
                        }

                        function x(t) {
                            switch (t.keyCode) {
                                case 37:
                                    B();
                                    break;
                                case 39:
                                    z();
                                    break;
                                case 27:
                                    P();
                                    break;
                                case 36:
                                    ! function(t) {
                                        t && t.preventDefault(), N(0)
                                    }(t);
                                    break;
                                case 35:
                                    ! function(t) {
                                        t && t.preventDefault(), N(h.length - 1)
                                    }(t)
                            }
                        }

                        function D(o, s) {
                            if (h !== o) {
                                for (h = o, function(o) {
                                        for (var s in o = o || {}, u) l[s] = u[s], void 0 !== o[s] && (l[s] = o[s]);
                                        e.style.transition = e.style.webkitTransition = "fadeIn" === l.animation ? "opacity .4s ease" : "slideIn" === l.animation ? "" : "none", "auto" === l.buttons && ("ontouchstart" in window || 1 === h.length) && (l.buttons = !1), n.style.display = i.style.display = l.buttons ? "" : "none";
                                        try {
                                            t.style.backgroundColor = l.overlayBackgroundColor
                                        } catch (t) {}
                                    }(s); e.firstChild;) e.removeChild(e.firstChild);
                                for (var r, a = [], c = [], f = g.length = 0; f < o.length; f++)(r = U("div")).className = "full-image", r.id = "baguette-img-" + f, g.push(r), a.push("baguetteBox-figure-" + f), c.push("baguetteBox-figcaption-" + f), e.appendChild(g[f]);
                                t.setAttribute("aria-labelledby", a.join(" ")), t.setAttribute("aria-describedby", c.join(" "))
                            }
                        }

                        function A(e) {
                            l.noScrollbars && (document.documentElement.style.overflowY = "hidden", document.body.style.overflowY = "scroll"), "block" !== t.style.display && (V(document, "keydown", x), p = {
                                count: 0,
                                startX: null,
                                startY: null
                            }, F(f = e, (function() {
                                H(f), q(f)
                            })), R(), t.style.display = "block", l.fullScreen && (t.requestFullscreen ? t.requestFullscreen() : t.webkitRequestFullscreen ? t.webkitRequestFullscreen() : t.mozRequestFullScreen && t.mozRequestFullScreen()), setTimeout((function() {
                                t.className = "visible", l.bodyClass && document.body.classList && document.body.classList.add(l.bodyClass), l.afterShow && l.afterShow()
                            }), 50), l.onChange && l.onChange(f, g.length), b = document.activeElement, M(), d = !0)
                        }

                        function M() {
                            l.buttons ? n.focus() : o.focus()
                        }

                        function P() {
                            l.noScrollbars && (document.documentElement.style.overflowY = "auto", document.body.style.overflowY = "auto"), "none" !== t.style.display && (W(document, "keydown", x), t.className = "", setTimeout((function() {
                                t.style.display = "none", document.fullscreen && (document.exitFullscreen ? document.exitFullscreen() : document.mozCancelFullScreen ? document.mozCancelFullScreen() : document.webkitExitFullscreen && document.webkitExitFullscreen()), l.bodyClass && document.body.classList && document.body.classList.remove(l.bodyClass), l.afterHide && l.afterHide(), b && b.focus(), d = !1
                            }), 500))
                        }

                        function F(t, e) {
                            var n = g[t],
                                i = h[t];
                            if (void 0 !== n && void 0 !== i)
                                if (n.getElementsByTagName("img")[0]) e && e();
                                else {
                                    var o = i.imageElement,
                                        s = o.getElementsByTagName("img")[0],
                                        r = "function" == typeof l.captions ? l.captions.call(h, o) : o.getAttribute("data-caption") || o.title,
                                        a = function(t) {
                                            var e = t.href;
                                            if (t.dataset) {
                                                var n = [];
                                                for (var i in t.dataset) "at-" !== i.substring(0, 3) || isNaN(i.substring(3)) || (n[i.replace("at-", "")] = t.dataset[i]);
                                                for (var o = Object.keys(n).sort((function(t, e) {
                                                        return parseInt(t, 10) < parseInt(e, 10) ? -1 : 1
                                                    })), s = window.innerWidth * window.devicePixelRatio, r = 0; r < o.length - 1 && o[r] < s;) r++;
                                                e = n[o[r]] || e
                                            }
                                            return e
                                        }(o),
                                        u = U("figure");
                                    if (u.id = "baguetteBox-figure-" + t, u.innerHTML = '<div class="baguetteBox-spinner"><div class="baguetteBox-double-bounce1"></div><div class="baguetteBox-double-bounce2"></div></div>', l.captions && r) {
                                        var c = U("figcaption");
                                        c.id = "baguetteBox-figcaption-" + t, c.innerHTML = r, u.appendChild(c)
                                    }
                                    n.appendChild(u);
                                    var f = U("img");
                                    f.onload = function() {
                                        var n = document.querySelector("#baguette-img-" + t + " .baguetteBox-spinner");
                                        u.removeChild(n), !l.async && e && e()
                                    }, f.setAttribute("src", a), f.alt = s && s.alt || "", l.titleTag && r && (f.title = r), u.appendChild(f), l.async && e && e()
                                }
                        }

                        function z() {
                            return N(f + 1)
                        }

                        function B() {
                            return N(f - 1)
                        }

                        function N(t, e) {
                            return !d && 0 <= t && t < e.length ? (D(e, l), A(t), !0) : t < 0 ? (l.animation && j("right"), !1) : t >= g.length ? (l.animation && j("right"), !1) : (F(f = t, (function() {
                                H(f), q(f)
                            })), R(), l.onChange && l.onChange(f, g.length), !0)
                        }

                        function j(t) {
                            e.className = "bounce-from-" + t, setTimeout((function() {
                                e.className = ""
                            }), 400)
                        }

                        function R() {
                            var t = 100 * f + "%";
                            "fadeIn" === l.animation ? (e.style.opacity = 0, setTimeout((function() {
                                c.transforms ? e.style.transform = e.style.webkitTransform = "translate3d(" + t + ",0,0)" : e.style.right = t, e.style.opacity = 1
                            }), 400)) : c.transforms ? e.style.transform = e.style.webkitTransform = "translate3d(" + t + ",0,0)" : e.style.right = t
                        }

                        function H(t) {
                            t - f >= l.preload || F(t + 1, (function() {
                                H(t + 1)
                            }))
                        }

                        function q(t) {
                            f - t >= l.preload || F(t - 1, (function() {
                                q(t - 1)
                            }))
                        }

                        function V(t, e, n, i) {
                            t.addEventListener ? t.addEventListener(e, n, i) : t.attachEvent("on" + e, (function(t) {
                                (t = t || window.event).target = t.target || t.srcElement, n(t)
                            }))
                        }

                        function W(t, e, n, i) {
                            t.removeEventListener ? t.removeEventListener(e, n, i) : t.detachEvent("on" + e, n)
                        }

                        function Y(t) {
                            return document.getElementById(t)
                        }

                        function U(t) {
                            return document.createElement(t)
                        }
                        return [].forEach || (Array.prototype.forEach = function(t, e) {
                            for (var n = 0; n < this.length; n++) t.call(e, this[n], n, this)
                        }), [].filter || (Array.prototype.filter = function(t, e, n, i, o) {
                            for (n = this, i = [], o = 0; o < n.length; o++) t.call(e, n[o], o, n) && i.push(n[o]);
                            return i
                        }), {
                            run: function(l, u) {
                                return c.transforms = function() {
                                        var t = U("div");
                                        return void 0 !== t.style.perspective || void 0 !== t.style.webkitPerspective
                                    }(), c.svg = function() {
                                        var t = U("div");
                                        return t.innerHTML = "<svg/>", "http://www.w3.org/2000/svg" === (t.firstChild && t.firstChild.namespaceURI)
                                    }(), c.passiveEvents = function() {
                                        var t = !1;
                                        try {
                                            var e = Object.defineProperty({}, "passive", {
                                                get: function() {
                                                    t = !0
                                                }
                                            });
                                            window.addEventListener("test", null, e)
                                        } catch (t) {}
                                        return t
                                    }(),
                                    function() {
                                        if (t = Y("baguetteBox-overlay")) return e = Y("baguetteBox-slider"), n = Y("previous-button"), i = Y("next-button"), void(o = Y("close-button"));
                                        (t = U("div")).setAttribute("role", "dialog"), t.id = "baguetteBox-overlay", document.getElementsByTagName("body")[0].appendChild(t), (e = U("div")).id = "baguetteBox-slider", t.appendChild(e), (n = U("button")).setAttribute("type", "button"), n.id = "previous-button", n.setAttribute("aria-label", "Previous"), n.innerHTML = c.svg ? s : "&lt;", t.appendChild(n), (i = U("button")).setAttribute("type", "button"), i.id = "next-button", i.setAttribute("aria-label", "Next"), i.innerHTML = c.svg ? r : "&gt;", t.appendChild(i), (o = U("button")).setAttribute("type", "button"), o.id = "close-button", o.setAttribute("aria-label", "Close"), o.innerHTML = c.svg ? a : "&times;", t.appendChild(o), n.className = i.className = o.className = "baguetteBox-button",
                                            function() {
                                                var s = c.passiveEvents ? {
                                                        passive: !1
                                                    } : null,
                                                    r = c.passiveEvents ? {
                                                        passive: !0
                                                    } : null;
                                                V(t, "click", _), V(n, "click", E), V(i, "click", w), V(o, "click", k), V(e, "contextmenu", C), V(t, "touchstart", I, r), V(t, "touchmove", T, s), V(t, "touchend", S), V(document, "focus", L, !0)
                                            }()
                                    }(), O(l),
                                    function(t, e) {
                                        var n = document.querySelectorAll(t),
                                            i = {
                                                galleries: [],
                                                nodeList: n
                                            };
                                        return y[t] = i, [].forEach.call(n, (function(t) {
                                            e && e.filter && (v = e.filter);
                                            var n = [];
                                            if (n = "A" === t.tagName ? [t] : t.getElementsByTagName("a"), 0 !== (n = [].filter.call(n, (function(t) {
                                                    if (-1 === t.className.indexOf(e && e.ignoreClass)) return v.test(t.href)
                                                }))).length) {
                                                var o = [];
                                                [].forEach.call(n, (function(t, n) {
                                                    var i = function(t) {
                                                            t.preventDefault ? t.preventDefault() : t.returnValue = !1, D(o, e), A(n)
                                                        },
                                                        s = {
                                                            eventHandler: i,
                                                            imageElement: t
                                                        };
                                                    V(t, "click", i), o.push(s)
                                                })), i.galleries.push(o)
                                            }
                                        })), i.galleries
                                    }(l, u)
                            },
                            show: N,
                            showNext: z,
                            showPrevious: B,
                            hide: P,
                            destroy: function() {
                                ! function() {
                                    var s = c.passiveEvents ? {
                                            passive: !1
                                        } : null,
                                        r = c.passiveEvents ? {
                                            passive: !0
                                        } : null;
                                    W(t, "click", _), W(n, "click", E), W(i, "click", w), W(o, "click", k), W(e, "contextmenu", C), W(t, "touchstart", I, r), W(t, "touchmove", T, s), W(t, "touchend", S), W(document, "focus", L, !0)
                                }(),
                                function() {
                                    for (var t in y) y.hasOwnProperty(t) && O(t)
                                }(), W(document, "keydown", x), document.getElementsByTagName("body")[0].removeChild(document.getElementById("baguetteBox-overlay")), y = {}, h = [], f = 0
                            }
                        }
                    }, void 0 === (o = "function" == typeof i ? i.call(e, n, e, t) : i) || (t.exports = o)
                }()
            }
        },
        e = {};

    function n(i) {
        var o = e[i];
        if (void 0 !== o) return o.exports;
        var s = e[i] = {
            exports: {}
        };
        return t[i].call(s.exports, s, s.exports, n), s.exports
    }
    n.n = t => {
        var e = t && t.__esModule ? () => t.default : () => t;
        return n.d(e, {
            a: e
        }), e
    }, n.d = (t, e) => {
        for (var i in e) n.o(e, i) && !n.o(t, i) && Object.defineProperty(t, i, {
            enumerable: !0,
            get: e[i]
        })
    }, n.o = (t, e) => Object.prototype.hasOwnProperty.call(t, e), (() => {
        "use strict";
        var t = n(731),
            e = n.n(t);

        function i(t, e) {
            var n = Object.keys(t);
            if (Object.getOwnPropertySymbols) {
                var i = Object.getOwnPropertySymbols(t);
                e && (i = i.filter((function(e) {
                    return Object.getOwnPropertyDescriptor(t, e).enumerable
                }))), n.push.apply(n, i)
            }
            return n
        }

        function o(t, e, n) {
            return e in t ? Object.defineProperty(t, e, {
                value: n,
                enumerable: !0,
                configurable: !0,
                writable: !0
            }) : t[e] = n, t
        }
        const s = function(t, n) {
            null !== t && e().run(t, n ? function(t) {
                for (var e = 1; e < arguments.length; e++) {
                    var n = null != arguments[e] ? arguments[e] : {};
                    e % 2 ? i(Object(n), !0).forEach((function(e) {
                        o(t, e, n[e])
                    })) : Object.getOwnPropertyDescriptors ? Object.defineProperties(t, Object.getOwnPropertyDescriptors(n)) : i(Object(n)).forEach((function(e) {
                        Object.defineProperty(t, e, Object.getOwnPropertyDescriptor(n, e))
                    }))
                }
                return t
            }({}, n) : {})
        };

        function r(t, e) {
            if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
        }

        function a(t, e) {
            for (var n = 0; n < e.length; n++) {
                var i = e[n];
                i.enumerable = i.enumerable || !1, i.configurable = !0, "value" in i && (i.writable = !0), Object.defineProperty(t, i.key, i)
            }
        }

        function l(t, e, n) {
            return e && a(t.prototype, e), n && a(t, n), t
        }

        function u(t) {
            return u = Object.setPrototypeOf ? Object.getPrototypeOf : function(t) {
                return t.__proto__ || Object.getPrototypeOf(t)
            }, u(t)
        }

        function c(t, e) {
            return c = Object.setPrototypeOf || function(t, e) {
                return t.__proto__ = e, t
            }, c(t, e)
        }

        function h(t, e) {
            return !e || "object" != typeof e && "function" != typeof e ? function(t) {
                if (void 0 === t) throw new ReferenceError("this hasn't been initialised - super() hasn't been called");
                return t
            }(t) : e
        }

        function f(t) {
            var e = function() {
                if ("undefined" == typeof Reflect || !Reflect.construct) return !1;
                if (Reflect.construct.sham) return !1;
                if ("function" == typeof Proxy) return !0;
                try {
                    return Boolean.prototype.valueOf.call(Reflect.construct(Boolean, [], (function() {}))), !0
                } catch (t) {
                    return !1
                }
            }();
            return function() {
                var n, i = u(t);
                if (e) {
                    var o = u(this).constructor;
                    n = Reflect.construct(i, arguments, o)
                } else n = i.apply(this, arguments);
                return h(this, n)
            }
        }
        var d = {
            exports: {}
        };

        function p() {}
        p.prototype = {
            on: function(t, e, n) {
                var i = this.e || (this.e = {});
                return (i[t] || (i[t] = [])).push({
                    fn: e,
                    ctx: n
                }), this
            },
            once: function(t, e, n) {
                var i = this;

                function o() {
                    i.off(t, o), e.apply(n, arguments)
                }
                return o._ = e, this.on(t, o, n)
            },
            emit: function(t) {
                for (var e = [].slice.call(arguments, 1), n = ((this.e || (this.e = {}))[t] || []).slice(), i = 0, o = n.length; i < o; i++) n[i].fn.apply(n[i].ctx, e);
                return this
            },
            off: function(t, e) {
                var n = this.e || (this.e = {}),
                    i = n[t],
                    o = [];
                if (i && e)
                    for (var s = 0, r = i.length; s < r; s++) i[s].fn !== e && i[s].fn._ !== e && o.push(i[s]);
                return o.length ? n[t] = o : delete n[t], this
            }
        }, d.exports = p, d.exports.TinyEmitter = p;
        var m = d.exports,
            v = "undefined" != typeof Element ? Element.prototype : {},
            y = v.matches || v.matchesSelector || v.webkitMatchesSelector || v.mozMatchesSelector || v.msMatchesSelector || v.oMatchesSelector,
            g = function(t, e) {
                if (!t || 1 !== t.nodeType) return !1;
                if (y) return y.call(t, e);
                for (var n = t.parentNode.querySelectorAll(e), i = 0; i < n.length; i++)
                    if (n[i] == t) return !0;
                return !1
            };
        var b = function(t, e) {
            var n, i, o, s, r = 0;
            return function() {
                n = this, i = arguments;
                var t = new Date - r;
                return s || (t >= e ? a() : s = setTimeout(a, e - t)), o
            };

            function a() {
                s = 0, r = +new Date, o = t.apply(n, i), n = null, i = null
            }
        };

        function _() {}

        function E(t) {
            return parseFloat(t) || 0
        }
        var w = function() {
                function t(e, n) {
                    r(this, t), this.x = E(e), this.y = E(n)
                }
                return l(t, null, [{
                    key: "equals",
                    value: function(t, e) {
                        return t.x === e.x && t.y === e.y
                    }
                }]), t
            }(),
            k = function() {
                function t(e, n, i, o, s) {
                    r(this, t), this.id = s, this.right = e, this.top = n, this.width = i, this.height = o
                }
                return l(t, null, [{
                    key: "intersects",
                    value: function(t, e) {
                        return t.right < e.right + e.width && e.right < t.right + t.width && t.top < e.top + e.height && e.top < t.top + t.height
                    }
                }]), t
            }(),
            I = {
                BASE: "shuffle",
                SHUFFLE_ITEM: "shuffle-item",
                VISIBLE: "shuffle-item--visible",
                HIDDEN: "shuffle-item--hidden"
            },
            T = 0,
            S = function() {
                function t(e, n) {
                    r(this, t), T += 1, this.id = T, this.element = e, this.isRTL = n, this.isVisible = !0, this.isHidden = !1
                }
                return l(t, [{
                    key: "show",
                    value: function() {
                        this.isVisible = !0, this.element.classList.remove(I.HIDDEN), this.element.classList.add(I.VISIBLE), this.element.removeAttribute("aria-hidden")
                    }
                }, {
                    key: "hide",
                    value: function() {
                        this.isVisible = !1, this.element.classList.remove(I.VISIBLE), this.element.classList.add(I.HIDDEN), this.element.setAttribute("aria-hidden", !0)
                    }
                }, {
                    key: "init",
                    value: function() {
                        this.addClasses([I.SHUFFLE_ITEM, I.VISIBLE]), this.applyCss(t.Css.INITIAL), this.applyCss(this.isRTL ? t.Css.DIRECTION.rtl : t.Css.DIRECTION.ltr), this.scale = t.Scale.VISIBLE, this.point = new w
                    }
                }, {
                    key: "addClasses",
                    value: function(t) {
                        var e = this;
                        t.forEach((function(t) {
                            e.element.classList.add(t)
                        }))
                    }
                }, {
                    key: "removeClasses",
                    value: function(t) {
                        var e = this;
                        t.forEach((function(t) {
                            e.element.classList.remove(t)
                        }))
                    }
                }, {
                    key: "applyCss",
                    value: function(t) {
                        var e = this;
                        Object.keys(t).forEach((function(n) {
                            e.element.style[n] = t[n]
                        }))
                    }
                }, {
                    key: "dispose",
                    value: function() {
                        this.removeClasses([I.HIDDEN, I.VISIBLE, I.SHUFFLE_ITEM]), this.element.removeAttribute("style"), this.element = null
                    }
                }]), t
            }();
        S.Css = {
            INITIAL: {
                position: "absolute",
                top: 0,
                visibility: "visible",
                willChange: "transform"
            },
            DIRECTION: {
                ltr: {
                    right: 0
                },
                rtl: {
                    left: 0
                }
            },
            VISIBLE: {
                before: {
                    opacity: 1,
                    visibility: "visible"
                },
                after: {
                    transitionDelay: ""
                }
            },
            HIDDEN: {
                before: {
                    opacity: 0
                },
                after: {
                    visibility: "hidden",
                    transitionDelay: ""
                }
            }
        }, S.Scale = {
            VISIBLE: 1,
            HIDDEN: .001
        };
        var C = null,
            L = function() {
                if (null !== C) return C;
                var t = document.body || document.documentElement,
                    e = document.createElement("div");
                e.style.cssText = "width:10px;padding:2px;box-sizing:border-box;", t.appendChild(e);
                var n = window.getComputedStyle(e, null).width;
                return C = 10 === Math.round(E(n)), t.removeChild(e), C
            };

        function O(t, e) {
            var n = arguments.length > 2 && void 0 !== arguments[2] ? arguments[2] : window.getComputedStyle(t, null),
                i = E(n[e]);
            return L() || "width" !== e ? L() || "height" !== e || (i += E(n.paddingTop) + E(n.paddingBottom) + E(n.borderTopWidth) + E(n.borderBottomWidth)) : i += E(n.paddingLeft) + E(n.paddingRight) + E(n.borderLeftWidth) + E(n.borderRightWidth), i
        }
        var x = {
            reverse: !1,
            by: null,
            compare: null,
            randomize: !1,
            key: "element"
        };

        function D(t, e) {
            var n = Object.assign({}, x, e),
                i = Array.from(t),
                o = !1;
            return t.length ? n.randomize ? function(t) {
                for (var e = t.length; e;) {
                    e -= 1;
                    var n = Math.floor(Math.random() * (e + 1)),
                        i = t[n];
                    t[n] = t[e], t[e] = i
                }
                return t
            }(t) : ("function" == typeof n.by ? t.sort((function(t, e) {
                if (o) return 0;
                var i = n.by(t[n.key]),
                    s = n.by(e[n.key]);
                return void 0 === i && void 0 === s ? (o = !0, 0) : i < s || "sortFirst" === i || "sortLast" === s ? -1 : i > s || "sortLast" === i || "sortFirst" === s ? 1 : 0
            })) : "function" == typeof n.compare && t.sort(n.compare), o ? i : (n.reverse && t.reverse(), t)) : []
        }
        var A = {},
            M = "transitionend",
            P = 0;

        function F(t) {
            return !!A[t] && (A[t].element.removeEventListener(M, A[t].listener), A[t] = null, !0)
        }

        function z(t, e) {
            var n = M + (P += 1),
                i = function(t) {
                    t.currentTarget === t.target && (F(n), e(t))
                };
            return t.addEventListener(M, i), A[n] = {
                element: t,
                listener: i
            }, n
        }

        function B(t) {
            return Math.max.apply(Math, t)
        }

        function N(t, e, n, i) {
            var o = t / e;
            return Math.abs(Math.round(o) - o) < i && (o = Math.round(o)), Math.min(Math.ceil(o), n)
        }

        function j(t, e, n) {
            if (1 === e) return t;
            for (var i = [], o = 0; o <= n - e; o++) i.push(B(t.slice(o, o + e)));
            return i
        }

        function R(t, e) {
            for (var n, i = (n = t, Math.min.apply(Math, n)), o = 0, s = t.length; o < s; o++)
                if (t[o] >= i - e && t[o] <= i + e) return o;
            return 0
        }

        function H(t, e) {
            var n = {};
            t.forEach((function(t) {
                n[t.top] ? n[t.top].push(t) : n[t.top] = [t]
            }));
            var i = [],
                o = [],
                s = [];
            return Object.keys(n).forEach((function(t) {
                var r = n[t];
                o.push(r);
                var a, l = r[r.length - 1],
                    u = l.right + l.width,
                    c = Math.round((e - u) / 2),
                    h = r,
                    f = !1;
                if (c > 0) {
                    var d = [];
                    (f = r.every((function(t) {
                        var e = new k(t.right + c, t.top, t.width, t.height, t.id),
                            n = !i.some((function(t) {
                                return k.intersects(e, t)
                            }));
                        return d.push(e), n
                    }))) && (h = d)
                }
                if (!f && r.some((function(t) {
                        return i.some((function(e) {
                            var n = k.intersects(t, e);
                            return n && (a = e), n
                        }))
                    }))) {
                    var p = s.findIndex((function(t) {
                        return t.includes(a)
                    }));
                    s.splice(p, 1, o[p])
                }
                i = i.concat(h), s.push(h)
            })), [].concat.apply([], s).sort((function(t, e) {
                return t.id - e.id
            })).map((function(t) {
                return new w(t.right, t.top)
            }))
        }

        function q(t) {
            return Array.from(new Set(t))
        }
        var V = 0,
            W = function(t) {
                ! function(t, e) {
                    if ("function" != typeof e && null !== e) throw new TypeError("Super expression must either be null or a function");
                    t.prototype = Object.create(e && e.prototype, {
                        constructor: {
                            value: t,
                            writable: !0,
                            configurable: !0
                        }
                    }), e && c(t, e)
                }(n, t);
                var e = f(n);

                function n(t) {
                    var i, o = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : {};
                    r(this, n), (i = e.call(this)).options = Object.assign({}, n.options, o), i.options.delimeter && (i.options.delimiter = i.options.delimeter), i.lastSort = {}, i.group = n.ALL_ITEMS, i.lastFilter = n.ALL_ITEMS, i.isEnabled = !0, i.isDestroyed = !1, i.isInitialized = !1, i._transitions = [], i.isTransitioning = !1, i._queue = [];
                    var s = i._getElementOption(t);
                    if (!s) throw new TypeError("Shuffle needs to be initialized with an element.");
                    return i.element = s, i.id = "shuffle_" + V, V += 1, i._init(), i.isInitialized = !0, i
                }
                return l(n, [{
                    key: "_init",
                    value: function() {
                        if (this.items = this._getItems(), this.sortedItems = this.items, this.options.sizer = this._getElementOption(this.options.sizer), this.element.classList.add(n.Classes.BASE), this._initItems(this.items), this._onResize = this._getResizeFunction(), window.addEventListener("resize", this._onResize), "complete" !== document.readyState) {
                            var t = this.layout.bind(this);
                            window.addEventListener("load", (function e() {
                                window.removeEventListener("load", e), t()
                            }))
                        }
                        var e = window.getComputedStyle(this.element, null),
                            i = n.getSize(this.element).width;
                        this._validateStyles(e), this._setColumns(i), this.filter(this.options.group, this.options.initialSort), this.element.offsetWidth, this.setItemTransitions(this.items), this.element.style.transition = "height ".concat(this.options.speed, "ms ").concat(this.options.easing)
                    }
                }, {
                    key: "_getResizeFunction",
                    value: function() {
                        var t = this._handleResize.bind(this);
                        return this.options.throttle ? this.options.throttle(t, this.options.throttleTime) : t
                    }
                }, {
                    key: "_getElementOption",
                    value: function(t) {
                        return "string" == typeof t ? this.element.querySelector(t) : t && t.nodeType && 1 === t.nodeType ? t : t && t.jquery ? t[0] : null
                    }
                }, {
                    key: "_validateStyles",
                    value: function(t) {
                        "static" === t.position && (this.element.style.position = "relative"), "hidden" !== t.overflow && (this.element.style.overflow = "hidden")
                    }
                }, {
                    key: "_filter",
                    value: function() {
                        var t = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : this.lastFilter,
                            e = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : this.items,
                            n = this._getFilteredSets(t, e);
                        return this._toggleFilterClasses(n), this.lastFilter = t, "string" == typeof t && (this.group = t), n
                    }
                }, {
                    key: "_getFilteredSets",
                    value: function(t, e) {
                        var i = this,
                            o = [],
                            s = [];
                        return t === n.ALL_ITEMS ? o = e : e.forEach((function(e) {
                            i._doesPassFilter(t, e.element) ? o.push(e) : s.push(e)
                        })), {
                            visible: o,
                            hidden: s
                        }
                    }
                }, {
                    key: "_doesPassFilter",
                    value: function(t, e) {
                        if ("function" == typeof t) return t.call(e, e, this);
                        var i = e.getAttribute("data-" + n.FILTER_ATTRIBUTE_KEY),
                            o = this.options.delimiter ? i.split(this.options.delimiter) : JSON.parse(i);

                        function s(t) {
                            return o.includes(t)
                        }
                        return Array.isArray(t) ? this.options.filterMode === n.FilterMode.ANY ? t.some(s) : t.every(s) : o.includes(t)
                    }
                }, {
                    key: "_toggleFilterClasses",
                    value: function(t) {
                        var e = t.visible,
                            n = t.hidden;
                        e.forEach((function(t) {
                            t.show()
                        })), n.forEach((function(t) {
                            t.hide()
                        }))
                    }
                }, {
                    key: "_initItems",
                    value: function(t) {
                        t.forEach((function(t) {
                            t.init()
                        }))
                    }
                }, {
                    key: "_disposeItems",
                    value: function(t) {
                        t.forEach((function(t) {
                            t.dispose()
                        }))
                    }
                }, {
                    key: "_updateItemCount",
                    value: function() {
                        this.visibleItems = this._getFilteredItems().length
                    }
                }, {
                    key: "setItemTransitions",
                    value: function(t) {
                        var e = this.options,
                            n = e.speed,
                            i = e.easing,
                            o = this.options.useTransforms ? ["transform"] : ["top", "right"],
                            s = Object.keys(S.Css.HIDDEN.before).map((function(t) {
                                return t.replace(/([A-Z])/g, (function(t, e) {
                                    return "-".concat(e.toLowerCase())
                                }))
                            })),
                            r = o.concat(s).join();
                        t.forEach((function(t) {
                            t.element.style.transitionDuration = n + "ms", t.element.style.transitionTimingFunction = i, t.element.style.transitionProperty = r
                        }))
                    }
                }, {
                    key: "_getItems",
                    value: function() {
                        var t = this;
                        return Array.from(this.element.children).filter((function(e) {
                            return g(e, t.options.itemSelector)
                        })).map((function(e) {
                            return new S(e, t.options.isRTL)
                        }))
                    }
                }, {
                    key: "_mergeNewItems",
                    value: function(t) {
                        var e = Array.from(this.element.children);
                        return D(this.items.concat(t), {
                            by: function(t) {
                                return e.indexOf(t)
                            }
                        })
                    }
                }, {
                    key: "_getFilteredItems",
                    value: function() {
                        return this.items.filter((function(t) {
                            return t.isVisible
                        }))
                    }
                }, {
                    key: "_getConcealedItems",
                    value: function() {
                        return this.items.filter((function(t) {
                            return !t.isVisible
                        }))
                    }
                }, {
                    key: "_getColumnSize",
                    value: function(t, e) {
                        var i;
                        return 0 === (i = "function" == typeof this.options.columnWidth ? this.options.columnWidth(t) : this.options.sizer ? n.getSize(this.options.sizer).width : this.options.columnWidth ? this.options.columnWidth : this.items.length > 0 ? n.getSize(this.items[0].element, !0).width : t) && (i = t), i + e
                    }
                }, {
                    key: "_getGutterSize",
                    value: function(t) {
                        return "function" == typeof this.options.gutterWidth ? this.options.gutterWidth(t) : this.options.sizer ? O(this.options.sizer, "marginLeft") : this.options.gutterWidth
                    }
                }, {
                    key: "_setColumns",
                    value: function() {
                        var t = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : n.getSize(this.element).width,
                            e = this._getGutterSize(t),
                            i = this._getColumnSize(t, e),
                            o = (t + e) / i;
                        Math.abs(Math.round(o) - o) < this.options.columnThreshold && (o = Math.round(o)), this.cols = Math.max(Math.floor(o || 0), 1), this.containerWidth = t, this.colWidth = i
                    }
                }, {
                    key: "_setContainerSize",
                    value: function() {
                        this.element.style.height = this._getContainerSize() + "px"
                    }
                }, {
                    key: "_getContainerSize",
                    value: function() {
                        return B(this.positions)
                    }
                }, {
                    key: "_getStaggerAmount",
                    value: function(t) {
                        return Math.min(t * this.options.staggerAmount, this.options.staggerAmountMax)
                    }
                }, {
                    key: "_dispatch",
                    value: function(t) {
                        var e = arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : {};
                        this.isDestroyed || (e.shuffle = this, this.emit(t, e))
                    }
                }, {
                    key: "_resetCols",
                    value: function() {
                        var t = this.cols;
                        for (this.positions = []; t;) t -= 1, this.positions.push(0)
                    }
                }, {
                    key: "_layout",
                    value: function(t) {
                        var e = this,
                            n = this._getNextPositions(t),
                            i = 0;
                        t.forEach((function(t, o) {
                            function s() {
                                t.applyCss(S.Css.VISIBLE.after)
                            }
                            if (w.equals(t.point, n[o]) && !t.isHidden) return t.applyCss(S.Css.VISIBLE.before), void s();
                            t.point = n[o], t.scale = S.Scale.VISIBLE, t.isHidden = !1;
                            var r = e.getStylesForTransition(t, S.Css.VISIBLE.before);
                            r.transitionDelay = e._getStaggerAmount(i) + "ms", e._queue.push({
                                item: t,
                                styles: r,
                                callback: s
                            }), i += 1
                        }))
                    }
                }, {
                    key: "_getNextPositions",
                    value: function(t) {
                        var e = this;
                        if (this.options.isCentered) {
                            var i = t.map((function(t, i) {
                                var o = n.getSize(t.element, !0),
                                    s = e._getItemPosition(o);
                                return new k(s.x, s.y, o.width, o.height, i)
                            }));
                            return this.getTransformedPositions(i, this.containerWidth)
                        }
                        return t.map((function(t) {
                            return e._getItemPosition(n.getSize(t.element, !0))
                        }))
                    }
                }, {
                    key: "_getItemPosition",
                    value: function(t) {
                        return function(t) {
                            for (var e = t.itemSize, n = t.positions, i = t.gridSize, o = t.total, s = t.threshold, r = t.buffer, a = N(e.width, i, o, s), l = j(n, a, o), u = R(l, r), c = new w(i * u, l[u]), h = l[u] + e.height, f = 0; f < a; f++) n[u + f] = h;
                            return c
                        }({
                            itemSize: t,
                            positions: this.positions,
                            gridSize: this.colWidth,
                            total: this.cols,
                            threshold: this.options.columnThreshold,
                            buffer: this.options.buffer
                        })
                    }
                }, {
                    key: "getTransformedPositions",
                    value: function(t, e) {
                        return H(t, e)
                    }
                }, {
                    key: "_shrink",
                    value: function() {
                        var t = this,
                            e = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : this._getConcealedItems(),
                            n = 0;
                        e.forEach((function(e) {
                            function i() {
                                e.applyCss(S.Css.HIDDEN.after)
                            }
                            if (e.isHidden) return e.applyCss(S.Css.HIDDEN.before), void i();
                            e.scale = S.Scale.HIDDEN, e.isHidden = !0;
                            var o = t.getStylesForTransition(e, S.Css.HIDDEN.before);
                            o.transitionDelay = t._getStaggerAmount(n) + "ms", t._queue.push({
                                item: e,
                                styles: o,
                                callback: i
                            }), n += 1
                        }))
                    }
                }, {
                    key: "_handleResize",
                    value: function() {
                        this.isEnabled && !this.isDestroyed && this.update()
                    }
                }, {
                    key: "getStylesForTransition",
                    value: function(t, e) {
                        var n = Object.assign({}, e);
                        if (this.options.useTransforms) {
                            var i = this.options.isRTL ? "" : "-",
                                o = this.options.roundTransforms ? Math.round(t.point.x) : t.point.x,
                                s = this.options.roundTransforms ? Math.round(t.point.y) : t.point.y;
                            n.transform = "translate(".concat(i).concat(o, "px, ").concat(s, "px) scale(").concat(t.scale, ")")
                        } else this.options.isRTL ? n.left = t.point.x + "px" : n.right = t.point.x + "px", n.top = t.point.y + "px";
                        return n
                    }
                }, {
                    key: "_whenTransitionDone",
                    value: function(t, e, n) {
                        var i = z(t, (function(t) {
                            e(), n(null, t)
                        }));
                        this._transitions.push(i)
                    }
                }, {
                    key: "_getTransitionFunction",
                    value: function(t) {
                        var e = this;
                        return function(n) {
                            t.item.applyCss(t.styles), e._whenTransitionDone(t.item.element, t.callback, n)
                        }
                    }
                }, {
                    key: "_processQueue",
                    value: function() {
                        this.isTransitioning && this._cancelMovement();
                        var t = this.options.speed > 0,
                            e = this._queue.length > 0;
                        e && t && this.isInitialized ? this._startTransitions(this._queue) : e ? (this._styleImmediately(this._queue), this._dispatch(n.EventType.LAYOUT)) : this._dispatch(n.EventType.LAYOUT), this._queue.length = 0
                    }
                }, {
                    key: "_startTransitions",
                    value: function(t) {
                        var e = this;
                        this.isTransitioning = !0,
                            function(t, e, n) {
                                n || ("function" == typeof e ? (n = e, e = null) : n = _);
                                var i = t && t.length;
                                if (!i) return n(null, []);
                                var o = !1,
                                    s = new Array(i);

                                function r(t) {
                                    return function(e, r) {
                                        if (!o) {
                                            if (e) return n(e, s), void(o = !0);
                                            s[t] = r, --i || n(null, s)
                                        }
                                    }
                                }
                                t.forEach(e ? function(t, n) {
                                    t.call(e, r(n))
                                } : function(t, e) {
                                    t(r(e))
                                })
                            }(t.map((function(t) {
                                return e._getTransitionFunction(t)
                            })), this._movementFinished.bind(this))
                    }
                }, {
                    key: "_cancelMovement",
                    value: function() {
                        this._transitions.forEach(F), this._transitions.length = 0, this.isTransitioning = !1
                    }
                }, {
                    key: "_styleImmediately",
                    value: function(t) {
                        if (t.length) {
                            var e = t.map((function(t) {
                                return t.item.element
                            }));
                            n._skipTransitions(e, (function() {
                                t.forEach((function(t) {
                                    t.item.applyCss(t.styles), t.callback()
                                }))
                            }))
                        }
                    }
                }, {
                    key: "_movementFinished",
                    value: function() {
                        this._transitions.length = 0, this.isTransitioning = !1, this._dispatch(n.EventType.LAYOUT)
                    }
                }, {
                    key: "filter",
                    value: function(t, e) {
                        this.isEnabled && ((!t || t && 0 === t.length) && (t = n.ALL_ITEMS), this._filter(t), this._shrink(), this._updateItemCount(), this.sort(e))
                    }
                }, {
                    key: "sort",
                    value: function() {
                        var t = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : this.lastSort;
                        if (this.isEnabled) {
                            this._resetCols();
                            var e = D(this._getFilteredItems(), t);
                            this.sortedItems = e, this._layout(e), this._processQueue(), this._setContainerSize(), this.lastSort = t
                        }
                    }
                }, {
                    key: "update",
                    value: function() {
                        var t = arguments.length > 0 && void 0 !== arguments[0] && arguments[0];
                        this.isEnabled && (t || this._setColumns(), this.sort())
                    }
                }, {
                    key: "layout",
                    value: function() {
                        this.update(!0)
                    }
                }, {
                    key: "add",
                    value: function(t) {
                        var e = this,
                            n = q(t).map((function(t) {
                                return new S(t, e.options.isRTL)
                            }));
                        this._initItems(n), this._resetCols();
                        var i = D(this._mergeNewItems(n), this.lastSort),
                            o = this._filter(this.lastFilter, i),
                            s = function(t) {
                                return n.includes(t)
                            },
                            r = function(t) {
                                t.scale = S.Scale.HIDDEN, t.isHidden = !0, t.applyCss(S.Css.HIDDEN.before), t.applyCss(S.Css.HIDDEN.after)
                            },
                            a = this._getNextPositions(o.visible);
                        o.visible.forEach((function(t, n) {
                            s(t) && (t.point = a[n], r(t), t.applyCss(e.getStylesForTransition(t, {})))
                        })), o.hidden.forEach((function(t) {
                            s(t) && r(t)
                        })), this.element.offsetWidth, this.setItemTransitions(n), this.items = this._mergeNewItems(n), this.filter(this.lastFilter)
                    }
                }, {
                    key: "disable",
                    value: function() {
                        this.isEnabled = !1
                    }
                }, {
                    key: "enable",
                    value: function() {
                        var t = !(arguments.length > 0 && void 0 !== arguments[0]) || arguments[0];
                        this.isEnabled = !0, t && this.update()
                    }
                }, {
                    key: "remove",
                    value: function(t) {
                        var e = this;
                        if (t.length) {
                            var i = q(t),
                                o = i.map((function(t) {
                                    return e.getItemByElement(t)
                                })).filter((function(t) {
                                    return !!t
                                }));
                            this._toggleFilterClasses({
                                visible: [],
                                hidden: o
                            }), this._shrink(o), this.sort(), this.items = this.items.filter((function(t) {
                                return !o.includes(t)
                            })), this._updateItemCount(), this.once(n.EventType.LAYOUT, (function() {
                                e._disposeItems(o), i.forEach((function(t) {
                                    t.parentNode.removeChild(t)
                                })), e._dispatch(n.EventType.REMOVED, {
                                    collection: i
                                })
                            }))
                        }
                    }
                }, {
                    key: "getItemByElement",
                    value: function(t) {
                        return this.items.find((function(e) {
                            return e.element === t
                        }))
                    }
                }, {
                    key: "resetItems",
                    value: function() {
                        var t = this;
                        this._disposeItems(this.items), this.isInitialized = !1, this.items = this._getItems(), this._initItems(this.items), this.once(n.EventType.LAYOUT, (function() {
                            t.setItemTransitions(t.items), t.isInitialized = !0
                        })), this.filter(this.lastFilter)
                    }
                }, {
                    key: "destroy",
                    value: function() {
                        this._cancelMovement(), window.removeEventListener("resize", this._onResize), this.element.classList.remove("shuffle"), this.element.removeAttribute("style"), this._disposeItems(this.items), this.items.length = 0, this._transitions.length = 0, this.options.sizer = null, this.element = null, this.isDestroyed = !0, this.isEnabled = !1
                    }
                }], [{
                    key: "getSize",
                    value: function(t) {
                        var e = arguments.length > 1 && void 0 !== arguments[1] && arguments[1],
                            n = window.getComputedStyle(t, null),
                            i = O(t, "width", n),
                            o = O(t, "height", n);
                        if (e) {
                            var s = O(t, "marginLeft", n),
                                r = O(t, "marginRight", n),
                                a = O(t, "marginTop", n),
                                l = O(t, "marginBottom", n);
                            i += s + r, o += a + l
                        }
                        return {
                            width: i,
                            height: o
                        }
                    }
                }, {
                    key: "_skipTransitions",
                    value: function(t, e) {
                        var n = t.map((function(t) {
                            var e = t.style,
                                n = e.transitionDuration,
                                i = e.transitionDelay;
                            return e.transitionDuration = "0ms", e.transitionDelay = "0ms", {
                                duration: n,
                                delay: i
                            }
                        }));
                        e(), t[0].offsetWidth, t.forEach((function(t, e) {
                            t.style.transitionDuration = n[e].duration, t.style.transitionDelay = n[e].delay
                        }))
                    }
                }]), n
            }(m);
        W.ShuffleItem = S, W.ALL_ITEMS = "all", W.FILTER_ATTRIBUTE_KEY = "groups", W.EventType = {
            LAYOUT: "shuffle:layout",
            REMOVED: "shuffle:removed"
        }, W.Classes = I, W.FilterMode = {
            ANY: "any",
            ALL: "all"
        }, W.options = {
            group: W.ALL_ITEMS,
            speed: 250,
            easing: "cubic-bezier(0.4, 0.0, 0.2, 1)",
            itemSelector: "*",
            sizer: null,
            gutterWidth: 0,
            columnWidth: 0,
            delimiter: null,
            buffer: 0,
            columnThreshold: .01,
            initialSort: null,
            throttle: b,
            throttleTime: 300,
            staggerAmount: 15,
            staggerAmountMax: 150,
            useTransforms: !0,
            filterMode: W.FilterMode.ANY,
            isCentered: !1,
            isRTL: !1,
            roundTransforms: !0
        }, W.Point = w, W.Rect = k, W.__sorter = D, W.__getColumnSpan = N, W.__getAvailablePositions = j, W.__getShortColumn = R, W.__getCenteredPositions = H;
        const Y = W;

        function U(t, e) {
            var n = Object.keys(t);
            if (Object.getOwnPropertySymbols) {
                var i = Object.getOwnPropertySymbols(t);
                e && (i = i.filter((function(e) {
                    return Object.getOwnPropertyDescriptor(t, e).enumerable
                }))), n.push.apply(n, i)
            }
            return n
        }

        function X(t, e, n) {
            return e in t ? Object.defineProperty(t, e, {
                value: n,
                enumerable: !0,
                configurable: !0,
                writable: !0
            }) : t[e] = n, t
        }
        const G = function(t, e, n) {
            var i = document.querySelector(t);
            if (i) {
                var o = new Y(i, function(t) {
                        for (var e = 1; e < arguments.length; e++) {
                            var n = null != arguments[e] ? arguments[e] : {};
                            e % 2 ? U(Object(n), !0).forEach((function(e) {
                                X(t, e, n[e])
                            })) : Object.getOwnPropertyDescriptors ? Object.defineProperties(t, Object.getOwnPropertyDescriptors(n)) : U(Object(n)).forEach((function(e) {
                                Object.defineProperty(t, e, Object.getOwnPropertyDescriptor(n, e))
                            }))
                        }
                        return t
                    }({}, n)),
                    s = document.querySelectorAll(e);
                s.forEach((function(t) {
                    t.addEventListener("click", (function(t) {
                        t.preventDefault();
                        for (var e = 0; e < s.length; e++) s[e].classList.remove("current");
                        this.classList.add("current");
                        var n = this.dataset.target;
                        o.filter(n)
                    }))
                }))
            }
        };
        document.addEventListener("DOMContentLoaded", (function() {
            s(".gallery_content-media"), G(".gallery_content-media", ".gallery_content-filters_filter", {
                itemSelector: ".gallery_content-media_item"
            })
        }))
    })()
})();