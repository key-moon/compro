// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2963/judge/6015573/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  ll a, b;
  cin >> a >> b;

  var is_valid = [&](ll price) {
    assert(price % a == 0);
    var real_cnt = price / a;
    var greedy_cnt = 0;
    greedy_cnt += price / b;
    price %= b;
    greedy_cnt += price / a;
    price %= a;
    greedy_cnt += price;
    return real_cnt < greedy_cnt;
  };

  for (ll bcnt = 1; bcnt <= a; bcnt++) {
    var min_price = b * bcnt;
    var max_price = b * bcnt + (b - 1);
    var max_acnt = max_price / a;
    var min_acnt = (min_price + a - 1) / a;

    if (not is_valid(max_acnt * a)) continue;

    ll invalid = min_acnt - 1, valid = max_acnt;
    while (valid - invalid > 1) {
      var mid = (invalid + valid) / 2;
      if (is_valid(mid * a)) valid = mid;
      else invalid = mid;
    }

    cout << valid * a << endl;
    return 0;
  }
  cout << -1 << endl;
  return 0;
}


