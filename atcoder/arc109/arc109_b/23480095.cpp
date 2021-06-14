// detail: https://atcoder.jp/contests/arc109/submissions/23480095
#include<bits/stdc++.h>
using ull = unsigned long long;
using namespace std;

ull solve1(ull n) {
  ull valid = 0;
  ull invalid = INT32_MAX;
  while (invalid - valid > 1) {
    ull mid = (valid + invalid) / 2;
    if (mid * (mid + 1) / 2 <= n + 1) valid = mid;
    else invalid = mid;
  }
  return n + 1 - valid;
}

ull solve2(ull n) {
  ull valid = 0;
  ull width = INT32_MAX;
  while (width > 1) {
    ull mid = valid + width / 2;
    if (mid * (mid + 1) / 2 <= n + 1) valid = mid;
    width -= width / 2;
  }
  return n + 1 - valid;
}

const int CNT = 10000000;
int main() {
  ull n;
  cin >> n;
  ull res = 0;
  for (int i = 0; i < CNT; i++) {
    res += solve2(n);
  }
  cerr << res << endl;
  cout << solve2(n) << endl;
}
