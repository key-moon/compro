// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1643/judge/5001324/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

int target;
int largebit;

int primary(string& s, int& i){
  int res;
  if (isalpha(s[i])){
    int ind = s[i] - 'a';
    if (ind == target) res = 0;
    else if (largebit >> ind & 1) res = 1;
    else res = -1;
    i++;
  }
  else{
    assert(s[i] == '('); i++;
    var a = primary(s, i);

    assert(s[i] == '<' || s[i] == '>');
    var op = s[i];
    i++;

    var b = primary(s, i);
    assert(s[i] == ')'); i++;

    if (op == '>') {
      res = a > b ? a : b;
    }
    else{
      res = a < b ? a : b;
    }
  }
  return res;
}

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);

  vector<ll> factori(16);
  factori[0] = 1;
  for (ll i = 1; i < factori.size(); i++){
    factori[i] = factori[i - 1] * i;
  }

  int n;
  while (cin >> n, n){
    string a;
    cin >> a;
    vector<int> inds(256, -1);
    for (int i = 0; i < n; i++){
      inds[a[i]] = i;
    }
    string s, t;
    cin >> s;
    cin >> t;

    var format = [&](string& str){
      for (int i = 0; i < str.size(); i++){
        if (isalpha(str[i])) {
          var num = inds[str[i]];
          str[i] = 'a' + num;
        }
      }
    };
    format(s);
    format(t);

    if (false) {
      target = 0;
      largebit = 2;
      int i = 0;
      var res1 = primary(s, i);
      i = 0;
      var res2 = primary(t, i);
      cerr << res1 << " " << res2 << endl;
    }
    ll res = 0;
    for (int i = 0; i < n; i++){
      target = i;
      for (int b = 0; b < (1 << n); b++){
        if (b >> i & 1) continue;
        largebit = b;
        int res1, res2;
        {
          int i = 0;
          res1 = primary(s, i);
          int j = 0;
          res2 = primary(t, j);
        }
        if (res1 == 0 && res2 == 0){
          int popcnt = 0;
          for (int i = 0; i < n; i++){
            if (b >> i & 1) popcnt++;
          }
          ll curres = factori[popcnt] * factori[n - popcnt - 1];
          res += curres;
        }
      }
    }
    cout << res << endl;
  }
  return 0;
}
