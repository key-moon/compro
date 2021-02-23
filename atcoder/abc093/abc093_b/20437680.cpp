// detail: https://atcoder.jp/contests/abc093/submissions/20437680
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b, k;
  cin >> a >> b >> k;
  set<int> st{};
  for (int i = a; i < a + k; i++) {
    st.insert(i);
  }
  for (int i = b - k + 1; i <= b; i++) {
    st.insert(i);
  }
  for (var&& i : st) {
    if (i < a || b < i) continue;
    cout << i << endl;
  }
}
