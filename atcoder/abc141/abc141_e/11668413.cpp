// detail: https://atcoder.jp/contests/abc141/submissions/11668413
#ifndef INCLUDED_ROLLING_HASH_HPP
#define INCLUDED_ROLLING_HASH_HPP

#include <vector>
#include <string>

class rolling_hash {
public:
	using u64 = std::uint_fast64_t;
	using size_type = std::uint_fast32_t;
	using i128 = __int128_t;

	static constexpr u64 MOD = (1uL << 61) - 1;
	static constexpr u64 base = 20200213;

	std::string str;
	std::vector<u64> hash_, pow;

private:
	static constexpr u64 mask30 = (1ul << 30) - 1;
	static constexpr u64 mask31 = (1ul << 31) - 1;

	u64 mul(i128 a, i128 b) const {
		i128 t = a * b;
		t = (t >> 61) + (t & MOD);
		
		if(t >= MOD) return t - MOD;
		return t;
	}
	size_type xorshift(size_type x) const {
		x ^= x << 13;
		x ^= x >> 17;
		x ^= x << 5;
		return x;
	}

public:
	rolling_hash(const rolling_hash &) = default;
	rolling_hash(rolling_hash&&) = default;

	rolling_hash() : str() {};
	rolling_hash(const std::string & str) : str(str) {
		hash_.resize(str.size() + 1, 0);
		pow.resize(str.size() + 1, 1);
		for(size_type i = 0; i < str.size(); i++) {
			hash_[i + 1] = mul(hash_[i], base) + xorshift(str[i] + 1);
			pow[i + 1] = mul(pow[i], base);
			if(hash_[i + 1] >= MOD) hash_[i + 1] -= MOD;
		}
	}

	u64 hash() const { return hash_.back(); }
	u64 hash(size_type l, size_type r) const {
		u64 ret = MOD + hash_[r] - mul(hash_[l], pow[r - l]);
		return ret < MOD ? ret : ret - MOD;
	}
	
	size_type size() const { return str.size(); }
};

#endif

#include <iostream>

int main() {
	int n; scanf("%d", &n);
	std::string s; std::cin >> s;
	
	int ans = 0;
	rolling_hash hash(s);
	for(int i = 0; i < s.size(); i++) {
		for(int j = i; j < s.size(); j++) {
			while(i + ans < j and j + ans < n) {
				if(hash.hash(i, i + ans + 1) != hash.hash(j, j + ans + 1)) break;
				ans++;
			}
		}
	}

	printf("%d\n", ans);
	return 0;
}
