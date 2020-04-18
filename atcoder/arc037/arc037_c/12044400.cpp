// detail: https://atcoder.jp/contests/arc037/submissions/12044400
#include <bits/stdc++.h>

#define var auto
#define ll long long
#define APPLY(a, f) f(a.begin(), a.end())
#define APPLY(a, f, ...) f(a.begin(), a.end(), __VA_ARGS__)
#define FUN(x, f) [&](auto& x){return f;}
#define FUN(x, y, f) [&](auto& x){return f;}

template<class Iter, class Func, class Return, class... Args>
Return& Apply(Iter& iter, Func& func, Args&... args){
    return func(iter.begin(), iter.end(), args...);
}

using namespace std;

int main() {
    ll n, k;
    cin >> n >> k;
    vector<ll> a(n);
    vector<ll> b(n);
    for (int i = 0; i < n; ++i) cin >> a[i];
    for (int i = 0; i < n; ++i) cin >> b[i];
    sort(a.begin(), a.end());
    sort(b.begin(), b.end());

    ll invalid = 0, valid = 1LL << 62;
    while (valid - invalid > 1){
        var mid = (valid + invalid) / 2;
        bool verdict;

        var res = accumulate(b.begin(), b.end(), 0, [&](ll x, ll y){
            return x + (upper_bound(a.begin(), a.end(), mid / y) - a.begin());
        });
        verdict = res >= k;

        if (verdict) valid = mid;
        else invalid = mid;
    }

    cout << valid << endl;
}
